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
    public static class UtilBroker
    {
        private static readonly int port = 1883;
        private static readonly string clientId = "Tiago-Mediatique";
        private static MqttClientOptions options;
        private static IMqttClient mqttClient;
        private static readonly MqttClientFactory mqttFactory = new MqttClientFactory();

        
        /// <summary>
        /// Envoie demande catalogue dès qu'il est connecté
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        public static async Task Connection(string username, string password, string host)
        {
            options = new MqttClientOptionsBuilder()
                .WithTcpServer(host, port)
                .WithCredentials(username, password)
                .WithClientId(clientId)
                .WithCleanSession()
                .Build();

            mqttClient = mqttFactory.CreateMqttClient();

            var connectResult = await mqttClient.ConnectAsync(options);

            if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic("global")
                    .WithNoLocal(true)
                    .Build());

                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    ReiceiveMessage(e);
                    return Task.CompletedTask;
                };
            }

            AskCatalog askCatalog = new AskCatalog();
            SendMessage(mqttClient, MessageType.DEMANDE_CATALOGUE, clientId, askCatalog, "global");
            await Task.Delay(100);
        }

        /// <summary>
        /// Quand il reçoit des messages
        /// </summary>
        /// <param name="message"></param>
        private static void ReiceiveMessage(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                GenericEnvelop enveloppe = JsonSerializer.Deserialize<GenericEnvelop>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (enveloppe.SenderId == clientId) return;
                switch (enveloppe.MessageType)
                {
                    case MessageType.ENVOIE_CATALOGUE:
                    {
                        UtilMusic.AddOtherMusic(enveloppe);
                        break;
                    }
                    case MessageType.DEMANDE_CATALOGUE:
                    {
                        SendCatalog sendCatalog = new SendCatalog();
                        sendCatalog.Content = UtilMusic.LocalMusic;
                        SendMessage(mqttClient, MessageType.ENVOIE_CATALOGUE, clientId, sendCatalog, "global");
                        break;
                    }
                    case MessageType.ENVOIE_FICHIER:
                    {
                        SendMusic enveloppeSendMusic = JsonSerializer.Deserialize<SendMusic>(enveloppe.EnvelopJson);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Envoie tous les types de message
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="type"></param>
        /// <param name="senderId"></param>
        /// <param name="content"></param>
        /// <param name="topic"></param>
        private static async void SendMessage(IMqttClient mqttClient, MessageType type, string senderId, IJsonSerializableMessage content, string topic)
        {
            try
            {
                GenericEnvelop enveloppe = new GenericEnvelop();
                enveloppe.SenderId = senderId;
                enveloppe.EnvelopJson = content.ToJson();
                enveloppe.MessageType = type;
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(JsonSerializer.Serialize(enveloppe))
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
                    .Build();

                await mqttClient.PublishAsync(message);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}