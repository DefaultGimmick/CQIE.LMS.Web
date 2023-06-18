using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CQIE.LMS.DBManager
{
    public interface IDbManager
    {
        /// <summary>
        /// DbContext上下文
        /// </summary>
        public CQIE.LMS.DBManager.DbContexts.LMSDbContext Ctx { get; }

        public bool Save<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : class;

    }
}
