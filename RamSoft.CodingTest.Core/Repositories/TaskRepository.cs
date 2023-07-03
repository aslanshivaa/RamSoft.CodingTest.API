using System;
using System.Collections.Generic;
using System.Text;

namespace RamSoft.CodingTest.Core.Repositories
{
    public class TaskRepository : RepositoryBase<Entities.ScrumTask>, ITaskRepository
    {
        public TaskRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
