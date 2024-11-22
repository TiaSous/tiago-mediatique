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

        public Broker(string user, string host, string pass)
        {
            username = user;
            password = pass;
            broker = host;

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

            SendMessage(topic, "HELLO, qui a des musiques ?");
            
            await Task.Delay(1000);

        }

        public void ReiceiveMessage(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                Debug.Write(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                Enveloppe enveloppe = JsonSerializer.Deserialize<Enveloppe>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (enveloppe.Content == $"HELLO, qui a des musiques ?" && enveloppe.Guid != clientId)
                {
                    Enveloppe response = new Enveloppe();
                    response.Content = "Je n'ai pas de musique";
                    response.Guid = clientId;
                    SendMessage("testTiago", "Je n'ai pas de musique");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
            
        }

        async public void SendMessage(string topic, string text)
        {
            Enveloppe enveloppe = new Enveloppe();
            enveloppe.Content = text;
            enveloppe.Guid = clientId;
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
