using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key] public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public short? Age { get; set; } //Dikkat: ? olacak mı olmayacak mı
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public string? ImageUrl { get; set; }
    }
}
