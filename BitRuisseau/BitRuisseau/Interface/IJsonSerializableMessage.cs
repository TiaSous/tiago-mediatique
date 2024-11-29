using System.Text.Json;

namespace BitRuisseau.Interface
{
    public interface IJsonSerializableMessage
    {
        public string ToJson();
    }
}
