using homeowork.Models;

namespace homeowork.Services
{
    public interface INote
    {
        Task<List<Note>> LoadNotes();
        Task SaveNote(Note n);
    }
}
