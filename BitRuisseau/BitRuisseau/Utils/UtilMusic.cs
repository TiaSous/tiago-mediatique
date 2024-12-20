using System.Text.Json;
using BitRuisseau.Classes;
using BitRuisseau.Classes.Enveloppe;
namespace BitRuisseau.Utils;

public static class Util
{
    private static List<MediaData> _localMusic = new List<MediaData>();
    private static Dictionary<string, List<MediaData>> _otherMusic = new Dictionary<string, List<MediaData>>();

    public static void AddMusic(MediaData media)
    {
        _localMusic.Add(media);
    }
    public static void AddOtherMusic(GenericEnvelope envelope)
    {
        SendCatalog enveloppeSendCatalog = JsonSerializer.Deserialize<SendCatalog>(envelope.EnveloppeJson);
        Console.WriteLine(enveloppeSendCatalog);
        if (_otherMusic.ContainsKey(envelope.SenderId))
        {
            _otherMusic[envelope.SenderId] = enveloppeSendCatalog.Content;
        }
        else
        {
            _otherMusic.Add(envelope.SenderId, new List<MediaData>());
            _otherMusic[envelope.SenderId] = enveloppeSendCatalog.Content;
        }
    }
}