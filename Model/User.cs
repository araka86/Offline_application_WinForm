using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }

        public string LoginId {  get; set; }

        public string Role {  get; set; }

        public int UniqId {  get; set; }

        public string Password { get; set; }
    }
}
