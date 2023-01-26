using BusinessLogicLevel.Models;
using SharedTypes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLevel.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(TaskModel taskModel);
        void EditTask(TaskModel taskModel);
        TaskModel GetTaskById(int taskId);
        IEnumerable<TaskModel> GetTasks();
        void DeleteTask(int taskId);
        void ChangeTaskStatus(int taskId, SharedTypes.Enums.TaskStatus taskStatus);
        void ChangeTaskPriority(int taskId, TaskPriority taskPriority);

    }
}
