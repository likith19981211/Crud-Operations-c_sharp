using simpleCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleCrud.Gateway
{
    public class TeacherGateway
    {
        AppDbContext dbContext = new AppDbContext();

        public bool Add(Teacher teacher)
        {
            dbContext.Teachers.Add(teacher);
          return dbContext.SaveChanges()>0;
        }

        public List<Teacher> getAll()
        {
            return dbContext.Teachers.ToList();
        }

        public bool Update(Teacher teacher)
        {
            var data = dbContext.Teachers.FirstOrDefault(c => c.Id == teacher.Id);
            if (data == null)
            {
                return false;
            }
            data.Name = teacher.Name;
            data.College = teacher.College;
            data.Experience = teacher.Experience;
            return dbContext.SaveChanges() > 0;

        }

        public bool Delete(int id)
        {
            var teacher = dbContext.Teachers.FirstOrDefault(c => c.Id == id);
            if(teacher == null)
            {
                return false;
            }
            dbContext.Teachers.Remove(teacher);
            return dbContext.SaveChanges() > 0;
        }
    }
}
