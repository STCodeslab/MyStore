using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }
    }
}
