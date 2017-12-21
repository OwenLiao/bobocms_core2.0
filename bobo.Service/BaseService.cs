using bobo.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Autofac;
using bobo.orm.efcore;

namespace bobo.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {

        BaseRepository<T> rep { get; }





        public T Add(T entity, bool isSave = true)
        {
           return rep.Add(entity, isSave);
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return rep.Count(predicate);
        }

        public bool Delete(T entity, bool isSave = true)
        {
            return rep.Delete(entity, isSave);
        }

        public bool Delete(int id, bool isSave = true)
        {
            return rep.Delete(id, isSave);
        }

        public bool Exist(System.Linq.Expressions.Expression<Func<T, bool>> anyLambda)
        {
            return rep.Exist(anyLambda);
        }

        public System.Linq.IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba)
        {
            return rep.GetList(whereLamdba);
        }

        public System.Linq.IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return rep.GetList(whereLamdba,orderName,isAsc);
        }

        public System.Linq.IQueryable<T> GetList(int top, System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return rep.GetList(top,whereLamdba, orderName, isAsc);
        }

        public System.Linq.IQueryable<T> GetList(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord)
        {
            return rep.GetList(pageSize,pageIndex, whereLamdba, orderName, isAsc,out totalRecord);
        }

        public T GetModel(int Id)
        {
            return rep.GetModel(Id);
        }

        public T GetModel(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return rep.GetModel(whereLambda);
        }

        public int Save()
        {
            return rep.Save();
        }

        public bool Update(T entity, bool isSave = true)
        {
           return rep.Update(entity, isSave);
        }
    }
}
