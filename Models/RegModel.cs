using System.ComponentModel.DataAnnotations;

namespace RegisterationForm.Models
{
    public class RegModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhNo { get; set; }
        public string Password { get; set; }
        
        public string ConformPass { get; set; }
    }
}
