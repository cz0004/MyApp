using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppBLL.IBLL
{
    public interface IBaseBLL<T> 
    {
        bool Add(T t);

        bool Add(T t, out int ID);

        bool Delete(List<int> IDs);

        bool Update(T t);

        T GetInfo(int ID);

        List<T> GetList();

        List<T> GetList(Func<T, bool> exp);

        List<T> GetList(int PageIndex, int PageSize, Func<T, string> order, string sortOrder, Func<T, bool> exp, out int count);
    }
}
