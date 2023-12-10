using System.ComponentModel;

namespace Autoservis01.Models
{
    public class MapperViewModel
    {
        public int Id { get; set; }
        [DisplayName("Brend")]
        public string? Brand { get; set; }
        [DisplayName("Model")]
        public string? Model { get; set; }
        [DisplayName("Price")]
        public int Price { get; set; }
    }
}
