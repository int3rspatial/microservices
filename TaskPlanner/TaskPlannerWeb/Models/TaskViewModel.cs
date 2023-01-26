using SharedTypes.Enums;
using System.ComponentModel;

namespace TaskPlannerWeb.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        [DisplayName("Estimated Time")]
        public int EstimatedTime { get; set; }
        [DisplayName("Task Priority")]
        public TaskPriority TaskPriority { get; set; }
        [DisplayName("Task Status")]
        public SharedTypes.Enums.TaskStatus TaskStatus { get; set; }
    }
}
