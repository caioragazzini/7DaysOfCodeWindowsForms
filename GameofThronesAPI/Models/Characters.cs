using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofThronesAPI.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Family { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }

    }
}
