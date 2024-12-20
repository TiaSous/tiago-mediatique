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
        public Accueil()
        {
            InitializeComponent();

            UtilMusic.UpdateLocalListMusic();
            LocalFileView.DataSource = UtilMusic.LocalMusic;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
           UtilBroker.Connection(User.Text, Password.Text, Host.Text);
        }

        private void Explorer_Click(object sender, EventArgs e)
        {
            ExplorerForm explorerForm = new ExplorerForm();
            explorerForm.ShowDialog();
        }
    }
}
