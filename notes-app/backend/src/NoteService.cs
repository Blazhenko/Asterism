namespace NotesApp;

public class NoteService
{
    public string[] ListNotes(string folder)
    {
        return Directory.GetFiles(folder, "*.md");
    }
    public string ReadNote(string path)
    {
        return File.ReadAllText(path);
    }
    public void SaveNote(string path, string content)
    {
        File.WriteAllText(path,content);
    }
    public void DeleteNote(string path)
    {
        File.Delete(path);
    }
    public string[] SearchNotes(string folder, string query)
    {
        var allFilles = Directory.GetFiles(folder);
        var results = new List<string>();

        foreach(var file in allFilles)
        {
            var text = File.ReadAllText(file);
            if(text.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(file);
            }
        }

        return results.ToArray();

    }
}