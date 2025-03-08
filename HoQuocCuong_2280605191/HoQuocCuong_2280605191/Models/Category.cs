using System.ComponentModel.DataAnnotations;

namespace HoQuocCuong_2280605191.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
