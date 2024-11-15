using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    public class MediaData
    {
        private string _file_name;
        private string _file_type;
        private int _file_size;
        private int _file_duration;

        public string File_name { get => _file_name; set => _file_name = value; }
        public string File_type { get => _file_type; set => _file_type = value; }
        public int File_size { get => _file_size; set => _file_size = value; }
        public int File_duration { get => _file_duration; set => _file_duration = value; }
    }
}
