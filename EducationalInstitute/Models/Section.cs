using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        [Required(ErrorMessage = "SectionName is required")]
        [StringLength(100)]
        public string SectionName { get; set; }

        public char? IsActive { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Exam>? Exam { get; set; }

    }
}
