using System.ComponentModel.DataAnnotations;

namespace MVCAPIs_Controller.Model
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
