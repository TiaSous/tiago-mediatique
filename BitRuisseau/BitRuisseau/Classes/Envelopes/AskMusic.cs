using System.Text.Json;
using BitRuisseau.Interface;

namespace BitRuisseau.Classes.Enveloppe;

public class AskMusic : IJsonSerializableMessage
{
    public string FileName { get; set; }


    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}