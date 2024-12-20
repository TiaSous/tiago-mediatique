using Microsoft.VisualBasic.ApplicationServices;
using MQTTnet.Protocol;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BitRuisseau.Classes;
using System.Text.Json;
using BitRuisseau.Classes.Enveloppe;
using BitRuisseau.Interface;

namespace BitRuisseau.Utils
{
    public class Broker
    {
        private readonly string broker;
        private readonly int port = 1883;
        private readonly string clientId = "Tiago-Mediatique";
        private readonly string username;
        private readonly string password;
        private readonly MqttClientOptions options;
        private readonly IMqttClient mqttClient;
        private readonly MqttClientFactory mqttFactory = new MqttClientFactory();
        private readonly List<MediaData> _maListMediaData;
        public Dictionary<string, List<MediaData>> otherMediaData = new Dictionary<string, List<MediaData>>();
        string topic = "thomasTest";
        
        public Broker(string user, string host, string pass, List<MediaData> mediaData)
        {
            username = user;
            password = pass;
            broker = host;
            _maListMediaData = mediaData;

            options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port)
            .WithCredentials(username, password)
            .WithClientId(clientId)
            .WithCleanSession()
            .Build();

            mqttClient = mqttFactory.CreateMqttClient();
        }
        /// Envoie demande catalogue dès qu'il est connecté
        async public void Connection()
        {
            

            var connectResult = await mqttClient.ConnectAsync(options);

            if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                // Subscribe to a topic
                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic(topic)
                    .WithNoLocal(true)
                    .Build());

                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    ReiceiveMessage(e);
                    return Task.CompletedTask;
                };
            }
            AskCatalog askCatalog = new AskCatalog();
            SendMessage(mqttClient, MessageType.DEMANDE_CATALOGUE, clientId, askCatalog, topic);
            
            await Task.Delay(1000);

        }

        /// Quand il reçoit des messages
        private void ReiceiveMessage(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                Debug.Write(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                GenericEnvelope enveloppe = JsonSerializer.Deserialize<GenericEnvelope>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (enveloppe.SenderId == clientId) return;
                switch (enveloppe.MessageType)
                {
                    case MessageType.ENVOIE_CATALOGUE:
                    {
                        SendCatalog enveloppeSendCatalog = JsonSerializer.Deserialize<SendCatalog>(enveloppe.EnveloppeJson);
                        Console.WriteLine(enveloppeSendCatalog);
                        if (otherMediaData.ContainsKey(enveloppe.SenderId))
                        {
                            otherMediaData[enveloppe.SenderId] = enveloppeSendCatalog.Content;
                        }
                        else
                        {
                            otherMediaData.Add(enveloppe.SenderId, new List<MediaData>());
                            otherMediaData[enveloppe.SenderId] = enveloppeSendCatalog.Content;
                        }
                        break;
                    }
                    case MessageType.DEMANDE_CATALOGUE:
                    {
                        SendCatalog sendCatalog = new SendCatalog();
                        sendCatalog.Content = _maListMediaData;
                        SendMessage(mqttClient, MessageType.ENVOIE_CATALOGUE, clientId, sendCatalog, topic);
                        break;
                    }
                    case MessageType.ENVOIE_FICHIER:
                    {
                        SendMusic enveloppeSendMusic = JsonSerializer.Deserialize<SendMusic>(enveloppe.EnveloppeJson);
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            } 
        }
        
        /// Envoie tous les types de message
        private async void SendMessage(IMqttClient mqttClient, MessageType type, string senderId, IJsonSerializableMessage content, string topic)
        {
            GenericEnvelope enveloppe = new GenericEnvelope();
            enveloppe.SenderId = senderId;
            enveloppe.EnveloppeJson = content.ToJson();
            enveloppe.MessageType = type;
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(JsonSerializer.Serialize(enveloppe))
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
                .Build();

            await mqttClient.PublishAsync(message);
            await Task.Delay(1000);
        }
    }
}
