using BitRuisseau.Interface;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau.Classes.Enveloppe
{
    public class DemandeCatalogue : IJsonSerializableMessage
    {
        public string Content { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
