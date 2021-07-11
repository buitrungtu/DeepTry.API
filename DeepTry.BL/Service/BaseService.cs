using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class BaseService<T>
    {
        BaseRepository<T> _baseRepository;
        public BaseService(BaseRepository<T> customerRepository)
        {
            _baseRepository = customerRepository;
        }
        public IEnumerable<T> GetFullData()
        {
            return _baseRepository.GetFullData();
        }

        public IEnumerable<T> GetDataByPage(int page, int record, Guid branchId)
        {
            return _baseRepository.GetDataByPage(page, record, branchId);
        }

        public T GetById(object objId)
        {
            return _baseRepository.GetByID(objId);
        }
        public ServiceResponse Insert(T obj)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(obj, "POST") == true) //check thông tin
            {
                serviceResponse.Success = true;
                serviceResponse.Data = _baseRepository.Insert(obj);
                if ((int)serviceResponse.Data > 0)
                {
                    serviceResponse.Message.Add("Thêm thành công");
                }
            }
            else
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
        public ServiceResponse Update(T obj)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(obj, "PUT") == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Data = _baseRepository.Update(obj);
                if ((int)serviceResponse.Data > 0)
                {
                    serviceResponse.Message.Add("Sửa thành công");
                }
            }
            else
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
        public ServiceResponse Delete(Guid objId)
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Data = _baseRepository.Delete(objId);
            if ((int)serviceResponse.Data > 0)
            {
                serviceResponse.Message.Add("Xóa thành công");
            }
            return serviceResponse;
        }
        public object ExecProc(string proc, object parameters, string action)
        {
            return _baseRepository.ExecProc(proc, parameters, action);
        }
        public object ExecuteQuery(string stringQuery, string action)
        {
            return _baseRepository.ExecuteQuery(stringQuery, action);
        }

        /// <summary>
        /// Validate thông tin trước khi thêm hoặc sửa (Sẽ thực hiện tại các lớp kế thừa)
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// Author: BTTu (27/06/2021)
        /// <returns></returns>
        protected virtual bool Validate(T entity, string Method)
        {
            return true;
        }
    }
}
