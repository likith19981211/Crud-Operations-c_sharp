using simpleCrud.Gateway;
using simpleCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleCrud.Manager
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public bool Add(Teacher teacher)
        {
            return teacherGateway.Add(teacher);
        }

        public List<Teacher> getAll()
        {
            return teacherGateway.getAll();
        }

        public bool Update(Teacher teacher)
        {
            return teacherGateway.Update(teacher);
        }

        public bool Delete(int id)
        {
            return teacherGateway.Delete(id);
        }

    }

   
}
