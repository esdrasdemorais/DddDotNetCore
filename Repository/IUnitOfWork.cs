using System;

namespace DddDotNetCore.Repository
{
    /* by Macoratti Reference */
    public interface IUnitOfWork
    {
        /* Sample Specific IRepository:
        ILayoutRepository LayoutRepository { get; }
        */

        void Commit();

        void Dispose();
    }
}