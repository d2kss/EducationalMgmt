using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class Subject
    {
        public int subjectId { get; set; }

        public string subjectName { get; set; }

        public int ClassID { get; set; }

        public int SectionId { get; set; }

        public char? IsActive { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public SClass? SClass { get; set; } = null!;

        public Section? Section { get; set; } = null!;
    }
}
