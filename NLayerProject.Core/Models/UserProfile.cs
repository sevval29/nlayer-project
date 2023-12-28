using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NickName { get; set; }
        //Foreign Key
        public int UserId { get; set; }
        // Bire-bir ilişki
        public User User { get; set; }

        
    }
}
