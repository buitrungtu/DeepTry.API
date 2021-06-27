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

        public IEnumerable<T> GetFullData()
        {
            return _databaseContext.GetFullData();
        }
        public IEnumerable<T> GetDataByPage(int page, int record)
        {
            return _databaseContext.GetDataByPage(page, record);
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
    }
}
