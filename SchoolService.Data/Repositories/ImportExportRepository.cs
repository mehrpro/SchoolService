using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolService.Data.Infrastructure;
using SchoolService.Models.Entities;

namespace SchoolService.Data.Repositories
{
    public interface IUserRepository : IRepository<ImportExport>
    {
        //------Definition Private Functions Model -------------//
        IList<ImportExport> GetActiveUsers();

    }
    public class ImportExportRepository : Repository<ImportExport>, IUserRepository
    {
        private readonly DbContext _db;
        public ImportExportRepository(DbContext dbContext) : base(dbContext)
        {
            this._db = (this._db ?? (ApplicationContext)_db);
        }

        public IList<ImportExport> GetActiveUsers()
        {
            var users = GetAll().ToList();
            return users;
        }
    }
}
