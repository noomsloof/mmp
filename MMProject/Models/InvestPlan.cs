using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MMProject.Models
{
    public class InvestPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("ชื่อแผน")]
        public string? Name { get; set; }

        [Required]
        [DisplayName("รายละเอียด")]
        public string? Description { get; set; }

        [Required]
        [DisplayName("ระยะเวลา(ปี)")]
        public int Time { get; set; }

        [Required]
        [DisplayName("ผลตอบแทน(%ต่อปี)")]
        public double YieldPerYear { get; set; }
    }
}
