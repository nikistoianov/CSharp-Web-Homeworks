namespace CHUSHKA.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
