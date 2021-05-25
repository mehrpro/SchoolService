using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolService.Data.Repositories;

namespace SchoolService.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {

        #region Fileds
        protected readonly DbContext db;

        #endregion

        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion

        #region Implement

        public void Commit()
        {
            db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }

        #endregion

        #region Repositories
        private ImportExportRepository _importExportRepository;
        public ImportExportRepository ImportExportRepository
        {
            get
            {
                if (_importExportRepository == null)
                {
                    _importExportRepository = new ImportExportRepository(db);
                }
                return _importExportRepository;
            }
        }
        #endregion

        #region Dispose

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
