using System.ComponentModel.DataAnnotations.Schema;

namespace icts_test.Entities.Entities
{
    [Table("tb_product")]
    public class Product : Notifies
    {
        [Column("prd_id")]
        public int Id { get; set; }
        [Column("prd_name")]
        public string Name { get; set; }
        [Column("prd_description")]
        public string Description { get; set; }
        [Column("prd_price")]
        public double Price { get; set; }
        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}