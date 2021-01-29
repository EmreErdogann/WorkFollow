using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Implementaions;
using WorkFollow.Data.Interfaces;

namespace EmployeeManagement.Data.Implementaions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkFollowDataContext _dbContext;
        public UnitOfWork(WorkFollowDataContext dbContext)
        {
            _dbContext = dbContext;
            reportRepository = new EfReportRepository(_dbContext);
            urgencyRepository = new EfUrgencyRepository(_dbContext);
            taskRepository = new EfTaskRepository(_dbContext);
            userRepository = new EfUserRepository(_dbContext);
        }

        public IReportRepository reportRepository { get; private set; }
        public IUrgencyRepository urgencyRepository { get; private set; }
        public ITaskRepository taskRepository { get; private set; }
        public IUserRepository userRepository { get; private set; }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();

        }

    }
}
