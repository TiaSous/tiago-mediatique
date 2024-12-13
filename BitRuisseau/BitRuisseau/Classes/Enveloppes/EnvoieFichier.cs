using BitRuisseau.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau.Classes.Enveloppe
{
    public class EnvoieFichier : IJsonSerializableMessage
    {
        public string Content { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
