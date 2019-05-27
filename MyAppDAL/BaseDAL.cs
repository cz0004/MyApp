using MyAppDAL.IDAL;
using System;
using System.Collections.Generic;
using System.Text;
using MyAppModel.EFModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;

namespace MyAppDAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class, new()
    {
        public virtual T FindOne(string exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().Where(exp).FirstOrDefault();
            }
        }


        public virtual IEnumerable<T> GetEntites(Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().Where(exp).ToList();
            }
        }

        public virtual bool Delete(T entity)
        {
            using (MyAppContext db = new MyAppContext())
            {
                var obj = db.Set<T>();
                obj.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }

        public virtual int GetEntitesCount(Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().Where(exp).Count();
            }
        }

        public virtual IEnumerable<T> GetEntities(Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().Where(exp).ToList();
            }
        }

        /// <summary>
        /// 无排序分页
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetEntitiesForPaging(int pageNumber, int pageSize, Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                pageNumber = (pageNumber / pageSize) + 1;
                return db.Set<T>().Where(exp).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// 有排序分页，只支持单个
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderName"></param>
        /// <param name="sortOrder"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetEntitiesForPaging(int pageNumber, int pageSize, Func<T, string> orderName, string sortOrder, Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                pageNumber = (pageNumber / pageSize) + 1;
                if (sortOrder == "asc")//升序排列
                {
                    return db.Set<T>().Where(exp).OrderBy(orderName).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                    //return db.Set<T>().Where(exp).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                }
                else
                {
                    return db.Set<T>().Where(exp).OrderByDescending(orderName).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                }
            }
        }

        public virtual T GetEntity(Func<T, bool> exp)
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().Where(exp).FirstOrDefault();
            }
        }

        public virtual bool Insert(T entity)
        {
            using (MyAppContext db = new MyAppContext())
            {
                var obj = db.Set<T>();
                obj.Add(entity);
                return db.SaveChanges() > 0;
            }
        }
        public virtual bool Insert(T entity, out int ID)
        {
            using (MyAppContext db = new MyAppContext())
            {
                var obj = db.Set<T>();
                obj.Add(entity);
                var re = db.SaveChanges() > 0;
                ID = 0;
                return re;
            }
        }
        public virtual bool Update(T entity)
        {
            using (MyAppContext db = new MyAppContext())
            {
                //var obj = db.Set<T>();
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public virtual IEnumerable<T> GetEntities()
        {
            using (MyAppContext db = new MyAppContext())
            {
                return db.Set<T>().ToList();
            }
        }

        public bool Insert(params T[] ts)
        {
            using (MyAppContext db = new MyAppContext())
            {
                var obj = db.Set<T>();
                obj.AddRange(ts);
                return db.SaveChanges() > 0;
            }
        }
    }
}
