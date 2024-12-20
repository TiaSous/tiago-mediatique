using System.Text.Json;
using BitRuisseau.Classes;
using BitRuisseau.Classes.Enveloppe;
namespace BitRuisseau.Utils;

public static class UtilMusic
{
    public static List<MediaData> LocalMusic { get; } = new List<MediaData>();
    public static Dictionary<string, List<MediaData>> OtherMusic { get; } = new Dictionary<string, List<MediaData>>();

    public static void AddMusic(MediaData media)
    {
        LocalMusic.Add(media);
    }
    public static void AddOtherMusic(GenericEnvelope envelope)
    {
        SendCatalog enveloppeSendCatalog = JsonSerializer.Deserialize<SendCatalog>(envelope.EnveloppeJson);
        Console.WriteLine(enveloppeSendCatalog);
        if (OtherMusic.ContainsKey(envelope.SenderId))
        {
            OtherMusic[envelope.SenderId] = enveloppeSendCatalog.Content;
        }
        else
        {
            OtherMusic.Add(envelope.SenderId, new List<MediaData>());
            OtherMusic[envelope.SenderId] = enveloppeSendCatalog.Content;
        }
    }

    public static void UpdateLocalListMusic()
    {
        if (!Directory.Exists("C:\\BitRuisseau"))
        {
            Directory.CreateDirectory("C:\\BitRuisseau");
        }
        string[] paths = Directory.GetFiles("C:\\BitRuisseau");

        foreach (string path in paths)
        {
            MediaData data = new MediaData();
            var tfile = TagLib.File.Create(path);

            FileInfo fileInfo = new FileInfo(path);
            data.Size = fileInfo.Length;

            data.Title = tfile.Tag.Title;
            data.Type = Path.GetExtension(path);
            data.Artist = tfile.Tag.FirstPerformer;
            TimeSpan duration = tfile.Properties.Duration;
            data.Duration = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
            AddMusic(data);
        }
    }
}