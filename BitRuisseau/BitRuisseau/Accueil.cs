using System.Diagnostics;
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
            ExplorerForm explorerForm = new();
            explorerForm.ShowDialog();
        }

        /// <summary>
        /// Permet d'actualiser les musique locales (affichage)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Actualiser_Click(object sender, EventArgs e)
        {
            UtilMusic.UpdateLocalListMusic();
            // Réinitialise la vue pour éviter les conflits de données et ne peut donc pas être enlevé comme demander par deepsource
            LocalFileView.DataSource = null; // skipcq: CS-W1082
            LocalFileView.DataSource = UtilMusic.LocalMusic;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LocalFileView.Refresh();
        }

        private void LocalFileView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                MediaData searchMusic = UtilMusic.LocalMusic[e.RowIndex];
                Process.Start(new ProcessStartInfo
                {
                    FileName = UtilMusic.pathMusics + "\\" + searchMusic.Title + searchMusic.Type,
                    UseShellExecute = true
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erreur : Ouverture du fichier impossible", "Échec de l'ouverture du fichier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
