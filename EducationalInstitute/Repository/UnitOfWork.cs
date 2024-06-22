using EducationalInstitute.Data;
using EducationalInstitute.Models;
using EducationalInstitute.Repository.Interface;

namespace EducationalInstitute.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<SClass> _classRepository;

        public IRepository<Teacher> _teacherRepository;
        public IRepository<Exam> _examRepository;
        public IRepository<Fees> _feesRepository;
        public IRepository<Section> _sectionRepository;
        public IRepository<Student> _studentRepository;
        public IRepository<Subject> _subjectRepository;
        public EducationalInstituteContext _Context { get; set; }
        public UnitOfWork(EducationalInstituteContext Context)
        {
            _Context = Context;
        }
        public IRepository<SClass> ClassRepository
        {
            get
            {
                if (_classRepository == null)
                {
                    _classRepository = new Repository<SClass>(_Context);
                }
                return _classRepository;
            }
        }

        public IRepository<Exam> ExamRepository
        {
            get
            {

                if (_examRepository == null)
                {
                    _examRepository = new Repository<Exam>(_Context);
                }
                return _examRepository;
            }
        }

        public IRepository<Fees> FeesRepository
        {
            get
            {

                if (_feesRepository == null)
                {
                    _feesRepository = new Repository<Fees>(_Context);
                }
                return _feesRepository;
            }
        }

        public IRepository<Section> SectionRepository
        {
            get
            {

                if (_sectionRepository == null)
                {
                    _sectionRepository = new Repository<Section>(_Context);
                }
                return _sectionRepository;
            }
        }

        public IRepository<Student> StudentRepository
        {
            get
            {

                if (_studentRepository == null)
                {
                    _studentRepository = new Repository<Student>(_Context);
                }
                return _studentRepository;
            }
        }

        public IRepository<Subject> SubjectRepository
        {
            get
            {

                if (_subjectRepository == null)
                {
                    _subjectRepository = new Repository<Subject>(_Context);
                }
                return _subjectRepository;
            }
        }

        public IRepository<Teacher> TeacherRepository
        {
            get
            {

                if (_teacherRepository == null)
                {
                    _teacherRepository = new Repository<Teacher>(_Context);
                }
                return _teacherRepository;
            }
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
