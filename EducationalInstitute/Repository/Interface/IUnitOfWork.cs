using EducationalInstitute.Models;

namespace EducationalInstitute.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<SClass> ClassRepository { get; }
        IRepository<Exam> ExamRepository { get; }

        IRepository<Fees> FeesRepository { get; }

        IRepository<Section> SectionRepository { get; }

        IRepository<Student> StudentRepository { get; }

        IRepository<Subject> SubjectRepository { get; }

        IRepository<Teacher> TeacherRepository { get; }

        void Save();
    }
}
