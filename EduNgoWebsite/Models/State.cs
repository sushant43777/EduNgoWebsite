using System.ComponentModel.DataAnnotations;

namespace EduNgoWebsite.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        public string? StateName { get; set; }
    }
}
