using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MMProject.Models
{
    public class Saving
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("วันที่")]
        public string Date { get; set; }

        [Required]
        [DisplayName("จำนวนเงิน")]
        public double Wealt { get; set; }
    }
}
