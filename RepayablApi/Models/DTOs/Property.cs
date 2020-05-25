using System.ComponentModel.DataAnnotations;

namespace RepayablApi.Models.DTOs
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public int Zip { get; set; }
        public int FloorCount { get; set; }
        [Required]
        [StringLength(50)]
        public string Remarks { get; set; }
        public int UserId { get; set; }

    }
}