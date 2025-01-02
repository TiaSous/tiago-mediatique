using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitRuisseau.Classes;
using BitRuisseau.Utils;

namespace BitRuisseau
{
    public partial class ExplorerForm : Form
    {
        private List<MediaData> sourceData;
        public ExplorerForm()
        {
            InitializeComponent();

            sourceData = UtilMusic.OtherMusic.Values.SelectMany(list => list).ToList();
            LocalFileView.DataSource = sourceData;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void LocalFileView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MediaData searchMusic = sourceData[e.RowIndex];
            UtilBroker.AskForMusic(searchMusic);
        }
    }
}
