using System.ComponentModel.DataAnnotations;

namespace RegisterationForm.Models
{
    public class RegTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhNo { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="enter your Password Properly")]

        public string ConformPass { get; set; }
    }
}
