using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace DeepTry.DL
{
    public class DBContext<T>
    {
        readonly string _connectionString = "workstation id=DeepTryDB.mssql.somee.com;packet size=4096;user id=tudefttry_SQLLogin_1;pwd=utnl7fvzym;data source=DeepTryDB.mssql.somee.com;persist security info=False;initial catalog=DeepTryDB";
        //readonly string _connectionString = "Server=DESKTOP-5K2RFED\\SQLEXPRESS;Database=QLCNH;Trusted_Connection=True;";
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;

        public DBContext()
        {
            // Khởi tạo kết nối:
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
            // Đối tượng xử lý command:
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure; //Base chỉ hỗ trợ proc
        }

        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public IEnumerable<T> GetDataByPage(int page, int record, Guid branchId)
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name; // Lấy ra kiểu dữ liệu
                _sqlCommand.CommandText = $"Proc_Get{className}sByPage";
                _sqlCommand.Parameters.Clear();
                _sqlCommand.Parameters.AddWithValue("brandID", branchId);
                _sqlCommand.Parameters.AddWithValue("Count", page);
                _sqlCommand.Parameters.AddWithValue("PageLimit", record);

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
            catch(Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Lấy full dữ liệu
        /// </summary>
        /// <returns></returns>
        /// @bttu 27.6.2021
        public IEnumerable<T> GetFullData(Guid branchId)
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{className}s";
                _sqlCommand.Parameters.Clear();
                _sqlCommand.Parameters.AddWithValue("brandID", branchId);
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
                    {
                        if(property.GetValue(obj) == null)
                        {
                            switch (param.DbType)
                            {
                                case System.Data.DbType.Guid:
                                    param.Value = new Guid("00000000-0000-0000-0000-000000000000");
                                    break;
                                case System.Data.DbType.DateTime:
                                    param.Value = DateTime.Now;
                                    break;
                                case System.Data.DbType.AnsiString:
                                case System.Data.DbType.String:
                                    param.Value = "";
                                    break;
                                default:
                                    param.Value = 0;
                                    break;
                            }
                        }
                        else
                        {
                            param.Value = property.GetValue(obj);
                        }
                    }

                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch(Exception ex)
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
                    {
                        if (property.GetValue(obj) == null)
                        {
                            switch (param.DbType)
                            {
                                case System.Data.DbType.Guid:
                                    param.Value = new Guid("00000000-0000-0000-0000-000000000000");
                                    break;
                                case System.Data.DbType.DateTime:
                                    param.Value = DateTime.Now;
                                    break;
                                case System.Data.DbType.AnsiString:
                                case System.Data.DbType.String:
                                    param.Value = "";
                                    break;
                                default:
                                    param.Value = 0;
                                    break;
                            }
                        }
                        else
                        {
                            param.Value = property.GetValue(obj);
                        }
                    }
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
                    _sqlCommand.Parameters[1].Value = objId;
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
        /// Thực hiện exec 1 proc trong db
        /// </summary>
        /// <param name="procName">Tên proc</param>
        /// <param name="p_parameters">object các tham số truyền vào</param
        /// <param name="action"> Proc này đọc hay là ghi </param>
        /// <returns></returns>
        /// @bttu
        public object ExecProc(string procName, object p_parameters, string action = "Read")
        {
            try
            {
                _sqlCommand.CommandText = $"{procName}";
                SqlCommandBuilder.DeriveParameters(_sqlCommand); //Lấy ra các tham số cần truyền của proc
                var parameters = _sqlCommand.Parameters;
                JObject parameter = JObject.Parse(p_parameters.ToString());
                foreach (SqlParameter param in parameters)
                {
                    var paramName = param.ParameterName.Replace("@", "");
                    if (paramName != "RETURN_VALUE")
                    {
                        param.Value = parameter[paramName].ToString();
                    }
                }
                if (action.ToLower() == "write")
                {
                    var affectRows = _sqlCommand.ExecuteNonQuery();
                    return affectRows;
                }
                else
                {
                    var objs = new List<JObject>();
                    SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        JObject obj = new JObject();

                        for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                        {

                            var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                            var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                            if (obj.ContainsKey(columnName))
                            {
                                obj[columnName] = value + "";
                            }
                            else
                            {
                                obj.Add(columnName, value + "");

                            }
                        }
                        objs.Add(obj);
                    }
                    mySqlDataReader.Close();
                    return objs;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh sql
        /// </summary>
        /// <param name="stringQuery">câu truy vấn</param>
        /// <param name="action"> Chiều đọc hay ghi </param>
        /// <returns></returns>
        public object ExecuteQuery(string stringQuery, string action = "Read")
        {
            try
            {
                _sqlCommand.CommandType = System.Data.CommandType.Text;
                _sqlCommand.CommandText = $"{stringQuery}";
                if (action.ToLower() == "write") //Ghi
                {
                    var affectRows = _sqlCommand.ExecuteNonQuery();

                    _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    return affectRows;
                }
                else //Đọc
                {
                    var objs = new List<JObject>();
                    SqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        JObject obj = new JObject();

                        for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                        {
                            var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                            var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                            if (obj.ContainsKey(columnName))
                            {
                                obj[columnName] = value + "";
                            }
                            else
                            {
                                obj.Add(columnName, value + "");

                            }
                        }
                        objs.Add(obj);
                    }
                    mySqlDataReader.Close();
                    _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    return objs;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }




        //Đóng kết nối
        public void Dispose()
        {
            _sqlConnection.Close();
        }
    }
}
