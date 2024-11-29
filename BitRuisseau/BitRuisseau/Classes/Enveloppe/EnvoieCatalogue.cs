using BitRuisseau.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau.Classes.Enveloppe
{
    public class EnvoieCatalogue : IJsonSerializableMessage
    {
        private List<MediaData> _content;

        public List<MediaData> Content { get => _content; set => _content = value; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
