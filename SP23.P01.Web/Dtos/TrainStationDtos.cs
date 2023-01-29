using System.ComponentModel.DataAnnotations;

namespace SP23.P01.Web.Dtos
{
    public class TrainStationDto
    {
        public int Id { get; set; }
        [MaxLength(120)]
        [StringLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }

    }
    public class TrainStationsCreateDto
    {
        [MaxLength(120)]
        [StringLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }

    }
    public class TrainStationsUpdateDto
    {
        [MaxLength(120)]
        [StringLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }

    }
}