using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class UserInformation
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string EMail { get; set; }

        //Foreign keys

        //Navigations Properties
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}