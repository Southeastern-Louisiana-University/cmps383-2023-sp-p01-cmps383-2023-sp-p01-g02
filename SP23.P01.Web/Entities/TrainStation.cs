using System.ComponentModel.DataAnnotations;

namespace SP23.P01.Web.Entities
{
    public class TrainStation
    {
        public int Id { get; set; }

        [MaxLength(120)]
        [StringLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
