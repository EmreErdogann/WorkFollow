using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFollow.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IReportRepository reportRepository { get; }
        public IUrgencyRepository urgencyRepository { get; }
        public ITaskRepository taskRepository { get; }
        public IUserRepository userRepository { get; }
        void Save();


    }
}
