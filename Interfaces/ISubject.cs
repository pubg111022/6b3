using pdf6b2.Models;

namespace pdf6b3.Interfaces
{
    public interface ISubject
    {
        List<Subject> GetSubjects();
        Subject Find(int id);

        Subject Insert(Subject subject);
        Subject Update(Subject subject,int i);
        Subject Delete(Subject e);
    }
}
