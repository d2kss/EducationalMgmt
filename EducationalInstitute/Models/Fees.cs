using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class Fees
    {
        [Key]
        public int FeesId { get; set; }

        public double Amount { get; set;}

        public int ClassId { get; set; }

        public char? IsActive { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public SClass? SClass { get; set; } = null!;

    }
}
