using System.Collections.Generic;
using System.Data;
using System.Linq;
using DapperExtensions;

namespace Sampler.Basic.Data.Dapper
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        private readonly IConnectionManager connectionManager;

        protected BaseRepository(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public TEntity Get(int id)
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                return dbConnection.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                return dbConnection.GetList<TEntity>().ToList();
            }
        }

        public int Insert(TEntity entity)
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                return dbConnection.Insert(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                return dbConnection.Update(entity);
            }
        }

        public bool Delete(TEntity entity)
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                return dbConnection.Delete(entity);
            }
        }
    }
}
