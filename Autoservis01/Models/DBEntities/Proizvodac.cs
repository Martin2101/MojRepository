using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autoservis01.Models.DBEntities
{
    public class Proizvodac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }

    }
}
