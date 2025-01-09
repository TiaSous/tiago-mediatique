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
        private static readonly string clientId = Guid.NewGuid().ToString();
        private static MqttClientOptions options;
        private static IMqttClient mqttClient;
        private static readonly MqttClientFactory mqttFactory = new();


        /// <summary>
        /// Envoie demande catalogue dès qu'il est connecté
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        public static async void Connection(string username, string password, string host)
        {
            try
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

                    await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                        .WithTopic(clientId)
                        .WithNoLocal(true)
                        .Build());

                    mqttClient.ApplicationMessageReceivedAsync += e =>
                    {
                        ReceiveMessage(e);
                        return Task.CompletedTask;
                    };
                    AskCatalog askCatalog = new();
                    SendMessage(MessageType.DEMANDE_CATALOGUE, clientId, askCatalog, "global");
                    MessageBox.Show("Connexion réussie!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Erreur : Identifiant non valide", "Échec de la connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Échec de la connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Quand il reçoit des messages.
        /// </summary>
        /// <param name="message"></param>
        private static void ReceiveMessage(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                GenericEnvelope envelope = JsonSerializer.Deserialize<GenericEnvelope>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (envelope.SenderId == clientId) return;
                switch (envelope.MessageType)
                {
                    case MessageType.ENVOIE_CATALOGUE:
                        {
                            UtilMusic.AddOtherMusic(envelope);
                            break;
                        }
                    case MessageType.DEMANDE_CATALOGUE:
                        {
                            SendCatalog sendCatalog = new();
                            sendCatalog.Content = UtilMusic.LocalMusic;
                            SendMessage(MessageType.ENVOIE_CATALOGUE, clientId, sendCatalog, "global");
                            break;
                        }
                    case MessageType.DEMANDE_FICHIER:
                        {
                            AskMusic askMusic = JsonSerializer.Deserialize<AskMusic>(envelope.EnvelopeJson);
                            SendMusic sendMusic = new();
                            sendMusic.Content = UtilMusic.TransformMediaInBase64(askMusic.FileName);
                            sendMusic.FileInfo = UtilMusic.GetMediaDataWithFileName(askMusic.FileName);
                            SendMessage(MessageType.ENVOIE_FICHIER, clientId, sendMusic, envelope.SenderId);
                            break;
                        }
                    case MessageType.ENVOIE_FICHIER:
                        {
                            SendMusic sendMusic = JsonSerializer.Deserialize<SendMusic>(envelope.EnvelopeJson);
                            UtilMusic.TransformBase64InMedia(sendMusic);
                            UtilMusic.UpdateLocalListMusic();
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
        /// Envoie tous les types de message.
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="type"></param>
        /// <param name="senderId"></param>
        /// <param name="content"></param>
        /// <param name="topic"></param>
        private static async void SendMessage(MessageType type, string senderId, IJsonSerializableMessage content, string topic)
        {
            try
            {
                GenericEnvelope envelope = new();
                envelope.SenderId = senderId;
                envelope.EnvelopeJson = content.ToJson();
                envelope.MessageType = type;
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(JsonSerializer.Serialize(envelope))
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

        public static void AskForMusic(MediaData mediaData)
        {
            AskMusic askMusic = new();
            askMusic.FileName = mediaData.Title + mediaData.Type;
            SendMessage(MessageType.DEMANDE_FICHIER, clientId, askMusic, UtilMusic.GetSomeoneWithMediaData(mediaData));
        }
    }
}