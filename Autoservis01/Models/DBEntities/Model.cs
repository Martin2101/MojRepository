using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autoservis01.Models.DBEntities
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]

        public int MakeId { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string? Brand { get; set; }

        public string? Series { get; set; } 
    }
}
