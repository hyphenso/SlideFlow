using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalSignageAPI.Models
{
    [Table("content")]
    public class Content
    {
        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("file_name")]
        public string FileName { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }
    }
}
