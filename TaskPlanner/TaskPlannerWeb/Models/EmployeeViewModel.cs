using BusinessLogicLevel.Models;
using System.ComponentModel;

namespace TaskPlannerWeb.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Free hours")]
        public int FreeHours { get; set; }
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
