using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoservis01.Models
{
    public class ProizvodacViewModel
    {
        public int Id { get; set; }
        [DisplayName("Brend")]
        public string? Brand { get; set; }
        [DisplayName("Model")]
        public string? Model { get; set; }
        public int Price { get; set; }
    }
}
