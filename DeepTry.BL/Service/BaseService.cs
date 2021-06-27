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

        public ServiceResponse Delete(Guid objId)
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Message.Add("Thành công");
            serviceResponse.Data = _baseRepository.Delete(objId);
            return serviceResponse;
        }

        public IEnumerable<T> GetFullData()
        {
            return _baseRepository.GetFullData();
        }

        public IEnumerable<T> GetDataByPage(int page, int record)
        {
            return _baseRepository.GetDataByPage(page, record);
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
                serviceResponse.Message.Add("Thành công");
                serviceResponse.Data = _baseRepository.Insert(obj);
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
                serviceResponse.Message.Add("Thành công");
                serviceResponse.Data = _baseRepository.Update(obj);
            }
            else
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
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
