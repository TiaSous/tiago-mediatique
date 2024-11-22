using BitRuisseau.Classes;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System.IO;
using System.Text;
using TagLib;

namespace BitRuisseau
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();

            if (!Directory.Exists("C:\\BitRuisseau"))
            {
                Directory.CreateDirectory("C:\\BitRuisseau");
            }
            string[] paths = Directory.GetFiles("C:\\BitRuisseau");

            List<MediaData> list = new List<MediaData>();

            foreach (string path in paths)
            {
                MediaData data = new MediaData();
                var tfile = TagLib.File.Create(path);

                FileInfo fileInfo = new FileInfo(path);
                data.File_size = fileInfo.Length;

                data.File_name = tfile.Tag.Title;
                data.File_type = Path.GetExtension(path);
                data.File_artist = tfile.Tag.FirstPerformer;
                TimeSpan duration = tfile.Properties.Duration;
                data.File_duration = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
                list.Add(data);
            }





            LocalFileView.DataSource = list;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void ValidateButton_Click(object sender, EventArgs e)
        {
            string broker = Host.Text;
            int port = 1883;
            string clientId = Guid.NewGuid().ToString();
            string topic = "test";
            string username = User.Text;
            string password = Password.Text;

            var factory = new MqttFactory();


            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port) // MQTT broker address and port
            .WithCredentials(username, password) // Set username and password
            .WithClientId(clientId)
            .WithCleanSession()
            .Build();


            var connectResult = await mqttClient.ConnectAsync(options);

            if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                Console.WriteLine("Connected to MQTT broker successfully.");

                // Subscribe to a topic
                await mqttClient.SubscribeAsync(topic);

                // Callback function when a message is received
                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    Console.WriteLine($"Received message: {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");
                    return Task.CompletedTask;
                };
            }

            for (int i = 0; i < 10; i++)
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload($"Salut thomas")
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .WithRetainFlag()
                    .Build();

                await mqttClient.PublishAsync(message);
                await Task.Delay(1000); // Wait for 1 second
            }
            await mqttClient.UnsubscribeAsync(topic);
            await mqttClient.DisconnectAsync();
        }
    }
}
