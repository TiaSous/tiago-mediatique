using BitRuisseau.Classes;
using BitRuisseau.Utils;
using MQTTnet;
using MQTTnet.Protocol;
using System.IO;
using System.Text;
using TagLib;

namespace BitRuisseau
{
    public partial class Accueil : Form
    {
        List<MediaData> list;
        Broker broker = null;
        public Accueil()
        {
            InitializeComponent();

            if (!Directory.Exists("C:\\BitRuisseau"))
            {
                Directory.CreateDirectory("C:\\BitRuisseau");
            }
            string[] paths = Directory.GetFiles("C:\\BitRuisseau");

            list = new List<MediaData>();

            foreach (string path in paths)
            {
                MediaData data = new MediaData();
                var tfile = TagLib.File.Create(path);

                FileInfo fileInfo = new FileInfo(path);
                data.Size = fileInfo.Length;

                data.Title = tfile.Tag.Title;
                data.Type = Path.GetExtension(path);
                data.Artist = tfile.Tag.FirstPerformer;
                TimeSpan duration = tfile.Properties.Duration;
                data.Duration = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
                list.Add(data);
            }
            LocalFileView.DataSource = list;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void ValidateButton_Click(object sender, EventArgs e)
        {
            broker = new Broker(User.Text, Host.Text, Password.Text, list);
            broker.Connection();
        }

        private void Explorer_Click(object sender, EventArgs e)
        {
            ExplorerForm explorerForm = new ExplorerForm(broker);
            explorerForm.ShowDialog();
        }
    }
}
