using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SP23.P01.Web.Dtos
{
	public class TrainStationsDto
	{
		[JsonIgnore]
		public int Id { get; set; }
		[StringLength(120)]
		[MaxLength(120)]
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Address { get; set; }
	}
}