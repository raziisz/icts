using System.ComponentModel.DataAnnotations.Schema;

namespace icts_test.Entities.Entities
{
    [Table("tb_category")]
    public class Category : Notifies
    {
        [Column("ctg_id")]
        public int Id { get; set; }
        [Column("ctg_name")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}