using System.ComponentModel.DataAnnotations;

namespace RepayablApi.Models.DTOs
{
    public class TenantDocument
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public byte[] Payload { get; set; }
        [Required]
        [StringLength(50)]
        public string MimeType { get; set; }
        [Required]
        [StringLength(50)]
        public string FileExtension { get; set; }
        public int TenantId { get; set; }
    }
}