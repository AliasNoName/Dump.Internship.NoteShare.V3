
namespace Dump.Internship.NoteShare.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsPremiumUser { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}