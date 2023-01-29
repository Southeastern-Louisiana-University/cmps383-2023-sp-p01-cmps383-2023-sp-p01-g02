using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
    public class TrainStationConfiguration : IEntityTypeConfiguration<TrainStation>
    {
        public void Configure(EntityTypeBuilder<TrainStation> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(t => t.Address)
                .IsRequired();

        }
    }
}
