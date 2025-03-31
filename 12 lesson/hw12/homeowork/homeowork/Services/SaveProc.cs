using homeowork.Models;

namespace homeowork.Services
{
    public class SaveProc : INote
    {
        private readonly string filePath = "notes.txt";

        public async Task<List<Note>> LoadNotes()
        {
            List<Note> notesCollection = new();

            if (File.Exists(filePath))
            {
                string[] lines = await File.ReadAllLinesAsync(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 3)
                    {
                        notesCollection.Add(new Note
                        {
                            Title = parts[0],
                            Text = parts[1],
                            CreatedAt = DateTime.Parse(parts[2]),
                            Tags = parts.Length > 3 ? parts[3] : null
                        });
                    }
                }
            }
            return notesCollection;
        }

        public async Task SaveNote(Note n)
        {
            string formattedNote = $"{n.Title}|{n.Text}|{n.CreatedAt}|{n.Tags}\n";
            await File.AppendAllTextAsync(filePath, formattedNote);
        }
    }
}
