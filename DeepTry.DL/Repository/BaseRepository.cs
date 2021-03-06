using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class BaseRepository<T>
    {
        protected DBContext<T> _databaseContext;

        public BaseRepository(DBContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<T> GetFullData(Guid branchId)
        {
            return _databaseContext.GetFullData(branchId);
        }
        public IEnumerable<T> GetDataByPage(int page, int record, Guid branchId)
        {
            return _databaseContext.GetDataByPage(page, record, branchId);
        }
        public T GetByID(object objID)
        {
            return _databaseContext.GetByID(objID);
        }
        public int Insert(T obj)
        {
            return _databaseContext.Insert(obj);
        }
        public int Update(T obj)
        {
            return _databaseContext.Update(obj);
        }
        public int Delete(Guid objID)
        {
            return _databaseContext.Delete(objID);
        }
        public object ExecProc(string proc, object parameters, string action)
        {
            return _databaseContext.ExecProc(proc, parameters, action);
        }
        public object ExecuteQuery(string stringQuery, string action)
        {
            return _databaseContext.ExecuteQuery(stringQuery, action);
        }
    }
}
