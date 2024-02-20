using System.ComponentModel.DataAnnotations;

namespace Custom_CV_Website__API.DAL.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
