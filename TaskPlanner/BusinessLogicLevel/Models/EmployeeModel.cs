using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLevel.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreeHours { get; set; }
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
