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
        public ExplorerForm(Broker broker)
        {
            InitializeComponent();
 
            List<MediaData> mediaData = broker.otherMediaData.Values.SelectMany(list => list).ToList();
            LocalFileView.DataSource = mediaData;
            LocalFileView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
    }
}
