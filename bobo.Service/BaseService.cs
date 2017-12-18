using bobo.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace bobo.Service
{
    public class BaseService : IBaseService<T> 
    {
        public System.Linq.IQueryable<T> Entities => throw new NotImplementedException();

        public T Add(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public bool Exist(System.Linq.Expressions.Expression<Func<T, bool>> anyLambda)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<T> GetList(int top, System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<T> GetList(int pageSize, int pageIndex, System.Linq.Expressions.Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord)
        {
            throw new NotImplementedException();
        }

        public T GetModel(int Id)
        {
            throw new NotImplementedException();
        }

        public T GetModel(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
