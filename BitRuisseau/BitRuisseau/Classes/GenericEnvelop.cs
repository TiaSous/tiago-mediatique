using BitRuisseau.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    public class GenericEnvelop
    {
        public MessageType MessageType { get; set; }

        public string SenderId { get; set; }

        public string EnveloppeJson { get; set; }
    }
}
