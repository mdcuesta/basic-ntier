using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DapperExtensions;
using Sampler.Basic.Core;
using Sampler.Basic.Data.Models;

namespace Sampler.Basic.Data.Dapper
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IConnectionManager connectionManager;
        private readonly IUserContext userContext;

        protected BaseRepository(IConnectionManager connectionManager, IUserContext userContext)
        {
            this.connectionManager = connectionManager;
            this.userContext = userContext;
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
                entity.UserCreated = this.userContext.UserId;
                entity.DateCreated = DateTime.UtcNow;
                return dbConnection.Insert(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                entity.UserModified = this.userContext.UserId;
                entity.DateModified = DateTime.UtcNow;
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
