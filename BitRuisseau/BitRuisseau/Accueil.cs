using BitRuisseau.Classes;
using System.IO;
using TagLib;

namespace BitRuisseau
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();

            if(!Directory.Exists("C:\\BitRuisseau"))
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
    }
}
