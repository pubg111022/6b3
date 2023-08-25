using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pdf6b2.Models;
using pdf6b3.Databases;
using pdf6b3.Interfaces;

namespace pdf6b3.Services
{
    public class SubjectService : ISubject
    {
        private  readonly StudentDbContext _dbContext;

        public SubjectService(StudentDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public Subject Delete(Subject e)
        {
            _dbContext.Remove(e);
            try
            {
                _dbContext.SaveChanges();
                return e;
            }
            catch (Exception)
            {
                return e;
                throw;
            }
        }

        public Subject Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetSubjects()
        {
            return _dbContext.Subjects.ToList();
        }

        public Subject Insert(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            try
            {
                _dbContext.SaveChangesAsync();
                return subject;
            }
            catch (Exception)
            {
                return subject;
            }
        }

        public Subject Update(Subject subject, int i)
        {
            _dbContext.Subjects.Update(subject);
            try
            {
                _dbContext.SaveChangesAsync();
                return subject;
            }
            catch (Exception)
            {
                return subject;
            }
        }
    }
}
