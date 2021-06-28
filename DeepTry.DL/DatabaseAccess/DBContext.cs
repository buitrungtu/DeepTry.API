using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DeepTry.DL
{
    public class DBContext<T>
    {
        readonly string _connectionString = "Server=DESKTOP-5K2RFED\\SQLEXPRESS;Database=QLCNH;Trusted_Connection=True;";
        /// <summary>
        /// ConnectionString:
        /// bttu: "Server=DESKTOP-5K2RFED\\SQLEXPRESS;Database=QLCNH;Trusted_Connection=True;"
        /// ndviet:
        /// nh:
        /// lvthang:
        /// tqhung:
        /// </summary>
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;

        public DBContext()
        {
            // Khởi tạo kết nối:
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
            // Đối tượng xử lý command:
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public IEnumerable<T> GetDataByPage(int page, int record)
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name; // Lấy ra kiểu dữ liệu
                _sqlCommand.CommandText = $"Proc_Get{className}sByPage";
                _sqlCommand.Parameters.AddWithValue("PageLimit", record);
                _sqlCommand.Parameters.AddWithValue("Count", page);

                SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var obj = Activator.CreateInstance<T>(); // tạo 1 đối tượng
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i); // lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i); // lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName); //Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                        {
                            propertyInfo.SetValue(obj, value);
                        }
                    }
                    objs.Add(obj);
                }
                mySqlDataReader.Close();
                return objs;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Lấy full dữ liệu
        /// </summary>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public IEnumerable<T> GetFullData()
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{className}s";
                SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var obj = Activator.CreateInstance<T>();

                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName);//Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                    objs.Add(obj);
                }
                mySqlDataReader.Close();
                return objs;
            }
            catch(Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Lấy thông tin qua id
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public T GetByID(object objId)
        {
            try
            {
                var className = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{className}ByID";
                SqlCommandBuilder.DeriveParameters(_sqlCommand);
                if (_sqlCommand.Parameters.Count > 0)
                {
                    _sqlCommand.Parameters[0].Value = objId;
                }
                SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                var obj = Activator.CreateInstance<T>();
                if (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName);//Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                }
                mySqlDataReader.Close();
                return obj;
            }
            catch
            {
                return default(T);
            }

        }

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public int Insert(T obj)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Insert{objType}";
                SqlCommandBuilder.DeriveParameters(_sqlCommand); //Lấy ra các tham số cần truyền của proc
                var parameters = _sqlCommand.Parameters;
                foreach (SqlParameter param in parameters)
                {
                    var paramName = param.ParameterName.Replace("@", "");
                    //Lấy ra property có tên là paramName và không phân biệt hoa thường
                    var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null)
                        param.Value = property.GetValue(obj);

                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public int Update(T obj)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Update{objType}";
                SqlCommandBuilder.DeriveParameters(_sqlCommand);//Lấy ra các tham số cần truyền của proc
                var parameters = _sqlCommand.Parameters;
                foreach (SqlParameter param in parameters)
                {
                    var paramName = param.ParameterName.Replace("@", "");
                    //Lấy ra property có tên là paramName và không phân biệt hoa thường
                    var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null)
                        param.Value = property.GetValue(obj);

                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public int Delete(Guid objId)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Delete{objType}";
                SqlCommandBuilder.DeriveParameters(_sqlCommand);//Lấy ra các tham số cần truyền của proc
                if (_sqlCommand.Parameters.Count > 0)
                {
                    _sqlCommand.Parameters[0].Value = objId;
                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }

        }

        //Đóng kết nối
        public void Dispose()
        {
            _sqlConnection.Close();
        }
    }
}
