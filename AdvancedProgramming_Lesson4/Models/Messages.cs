using System.ComponentModel.DataAnnotations;

namespace AdvancedProgramming_Lesson4.Models
{
    public class Messages
    {
        public int Id { get; set; }
        [Display(Name = "User")]
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool Authenticated { get; set; }
         
    }
}
