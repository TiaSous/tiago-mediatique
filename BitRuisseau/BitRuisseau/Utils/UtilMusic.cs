using System.Text.Json;
using BitRuisseau.Classes;
using BitRuisseau.Classes.Enveloppe;
namespace BitRuisseau.Utils;

public static class UtilMusic
{
    public static List<MediaData> LocalMusic { get; } = new List<MediaData>();
    public static Dictionary<string, List<MediaData>> OtherMusic { get; } = new Dictionary<string, List<MediaData>>();
    
    /// <summary>
    /// Ajoute la musique local
    /// </summary>
    /// <param name="media"></param>
    private static void AddMusic(MediaData media)
    {
        LocalMusic.Add(media);
    }
    
    /// <summary>
    /// Ajoute ou met à jour le catalogue des autres en plus
    /// </summary>
    /// <param name="envelop"></param>
    public static void AddOtherMusic(GenericEnvelop envelop)
    {
        SendCatalog enveloppeSendCatalog = JsonSerializer.Deserialize<SendCatalog>(envelop.EnveloppeJson);
        Console.WriteLine(enveloppeSendCatalog);
        if (OtherMusic.ContainsKey(envelop.SenderId))
        {
            OtherMusic[envelop.SenderId] = enveloppeSendCatalog.Content;
        }
        else
        {
            OtherMusic.Add(envelop.SenderId, new List<MediaData>());
            OtherMusic[envelop.SenderId] = enveloppeSendCatalog.Content;
        }
    }

    /// <summary>
    /// Met à jour la liste de musique local
    /// </summary>
    public static void UpdateLocalListMusic()
    {
        LocalMusic.Clear();
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

            data.Title = fileInfo.Name.Replace(fileInfo.Extension, "");
            data.Type = Path.GetExtension(path);
            data.Artist = tfile.Tag.FirstPerformer;
            TimeSpan duration = tfile.Properties.Duration;
            data.Duration = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
            AddMusic(data);
        }
    }
    
    /// <summary>
    /// Va retourner la 1ère personne qui trouve avec la musique
    /// </summary>
    /// <param name="media"></param>
    /// <returns></returns>
    public static string GetSomeoneWithMediaData(MediaData media)
    {
        return OtherMusic.First(keyValue => keyValue.Value.Contains(media)).Key;
    }

    public static MediaData GetMediaDataWithFileName(string fileName)
    {
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        return LocalMusic.First(music => music.Title == nameWithoutExtension);
    }
    
    public static string TransformMediaInBase64(string fileName)
    {
        string path = "C:\\BitRuisseau\\" + fileName;
        return Convert.ToBase64String(File.ReadAllBytes(path));
    }

    public static void TransformBase64InMedia(SendMusic musicData)
    {
        MediaData metaData = musicData.FileInfo;
        byte[] file = Convert.FromBase64String(musicData.Content);
        string path = "C:\\BitRuisseau\\" + metaData.Title + metaData.Type;
        File.WriteAllBytes(path, file);
    }
}