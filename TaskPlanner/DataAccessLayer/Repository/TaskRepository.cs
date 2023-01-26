using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DataAccessLayer.Entities.Task;

namespace DataAccessLayer.Repository
{
    public class TaskRepository: Repository<Task>, ITaskRepository
    {
        private ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Task task)
        {
            _db.Tasks.Update(task);
        }
    }
}
