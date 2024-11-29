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
        private string broker;
        private int port = 1883;
        private string clientId = Guid.NewGuid().ToString();
        private string username;
        private string password;
        private MqttClientOptions options;
        private IMqttClient mqttClient;
        private MqttClientFactory mqttFactory = new MqttClientFactory();
        private List<MediaData> listMediaData;

        public Broker(string user, string host, string pass, List<MediaData> mediaData)
        {
            username = user;
            password = pass;
            broker = host;
            listMediaData = mediaData;

            options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port)
            .WithCredentials(username, password)
            .WithClientId(clientId)
            .WithCleanSession()
            .Build();

            mqttClient = mqttFactory.CreateMqttClient();
        }

        async public void Connection()
        {
            string topic = "testTiago";

            var connectResult = await mqttClient.ConnectAsync(options);

            if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                Console.WriteLine("Connected to MQTT broker successfully.");

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
            DemandeCatalogue demandeCatalogue = new DemandeCatalogue();
            SendMessage(mqttClient, MessageType.DEMANDE_CATALOGUE, clientId, demandeCatalogue, topic);
            
            await Task.Delay(1000);

        }

        public void ReiceiveMessage(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                Debug.Write(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                GenericEnvelope enveloppe = JsonSerializer.Deserialize<GenericEnvelope>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (enveloppe.SenderId != clientId)
                {
                    if (enveloppe.MessageType == MessageType.ENVOIE_CATALOGUE)
                    {
                        EnvoieCatalogue enveloppeEnvoieCatalogue = JsonSerializer.Deserialize<EnvoieCatalogue>(enveloppe.EnveloppeJson);
                    }
                    else if (enveloppe.MessageType == MessageType.DEMANDE_CATALOGUE)
                    {
                        EnvoieCatalogue envoieCatalogue = new EnvoieCatalogue();
                        envoieCatalogue.Content = listMediaData;
                        SendMessage(mqttClient, MessageType.DEMANDE_CATALOGUE, clientId, envoieCatalogue, "test");

                    }
                    else if (enveloppe.MessageType == MessageType.ENVOIE_FICHIER)
                    {
                        EnvoieFichier enveloppeEnvoieFichier = JsonSerializer.Deserialize<EnvoieFichier>(enveloppe.EnveloppeJson);
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
            
        }

        async public void SendMessage(IMqttClient mqttClient, MessageType type, string senderId, IJsonSerializableMessage Content, string topic)
        {
            GenericEnvelope enveloppe = new GenericEnvelope();
            enveloppe.SenderId = senderId;
            enveloppe.EnveloppeJson = Content.ToJson();
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
