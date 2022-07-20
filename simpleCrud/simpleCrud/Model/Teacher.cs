using System.ComponentModel.DataAnnotations;

namespace simpleCrud.Model
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Experience { get; set; }
    }
}