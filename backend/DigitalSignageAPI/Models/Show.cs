using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalSignageAPI.Models
{
    [Table("show")]
    public class Show
    {
        [Column("show_id")]
        public int ShowId { get; set; }

        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("device_id")]
        public int DeviceId { get; set; }

        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("start")]
        public DateTime Start { get; set; }

        [Column("finish")]
        public DateTime Finish { get; set; }

        public Content Content { get; set; } = null!;
    }
}
