using SharedTypes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int EstimatedTime { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public SharedTypes.Enums.TaskStatus TaskStatus { get; set; }

    }
}
