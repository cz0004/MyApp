using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppDAL.IDAL
{
    public interface IBaseDAL<T>
    {
        T FindOne(string exp);

        IEnumerable<T> GetEntities();
        IEnumerable<T> GetEntities(Func<T, bool> exp);
        int GetEntitesCount(Func<T, bool> exp);
        /// <summary>
        /// 无排序
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        IEnumerable<T> GetEntitiesForPaging(int pageNumber, int pageSize, Func<T, bool> exp);
        /// <summary>
        /// 有排序，只支持单个
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderName"></param>
        /// <param name="sortOrder"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        IEnumerable<T> GetEntitiesForPaging(int pageNumber, int pageSize, Func<T, string> orderName, string sortOrder, Func<T, bool> exp);
        T GetEntity(Func<T, bool> exp);
        bool Insert(T entity);

        bool Insert(T entity, out int ID);
        bool Insert(params T[] ts);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
