using System.ComponentModel;

namespace Autoservis01.Models
{
    public class ModelViewModel
    {
        public int Id { get; set; }

        public int MakeId { get; set; }
        [DisplayName("Brand")]
        public string? Brand { get; set; }
        [DisplayName("Series")]
        public string? Series { get; set; }
    }
}
