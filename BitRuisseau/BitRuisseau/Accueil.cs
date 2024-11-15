using BitRuisseau.Classes;
using System.IO;

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
            List<FileInfo> files = Directory.GetFiles("C:\\BitRuisseau").Select(path => new FileInfo(path)).ToList();

            List<MediaData> list = new List<MediaData>();

            foreach (FileInfo file in files)
            {
                list.Add(new MediaData { File_duration = 0, File_name = file.Name, File_size = (int)file.Length, File_type = file.Extension });
            }


            LocalFileView.DataSource = list;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
