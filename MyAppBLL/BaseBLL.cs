using MyAppBLL.IBLL;
using MyAppDAL;
using MyAppDAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAppBLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {


        public virtual IBaseDAL<T> Dal { get; } = new BaseDAL<T>();

        public virtual bool Add(T t)
        {

            return Dal.Insert(t);
        }

        public virtual bool Add(T t, out int ID)
        {

            return Dal.Insert(t, out ID);
        }

        public virtual bool Add(params T[] ts)
        {
            return Dal.Insert(ts);
        }


        public virtual bool Delete(List<int> IDs)
        {
            if (IDs != null)
            {
                foreach (var item in IDs)
                {
                    var Info = GetInfo(item);
                    if (Info != null)
                    {
                        var isdelP = typeof(T).GetProperty("IsDel");
                        if (isdelP != null) isdelP.SetValue(Info, true);
                        isdelP = typeof(T).GetProperty("IsDelete");
                        if (isdelP != null) isdelP.SetValue(Info, true);
                        Dal.Update(Info);
                    }
                    else
                    {
                        continue;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual T GetInfo(int ID)
        {
            return Dal.FindOne($@"Id={ID}");
        }

        public virtual List<T> GetList()
        {
            return Dal.GetEntities().ToList();
        }

        public virtual List<T> GetList(Func<T, bool> exp)
        {
            return Dal.GetEntities(exp).ToList();
        }

        public virtual List<T> GetList(int PageIndex, int PageSize, Func<T, string> order, string sortOrder, Func<T, bool> exp, out int count)
        {
            count = Dal.GetEntitesCount(exp);
            var result = Dal.GetEntitiesForPaging(PageIndex, PageSize, order, sortOrder, exp).ToList();


            return result;
        }

        public virtual bool Update(T t)
        {
            return Dal.Update(t);
        }
    }
}
