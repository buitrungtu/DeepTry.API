using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class DBAction
    {
        /// <summary>
        /// Câu lệnh truy vấn hoặc tên proc
        /// </summary>
        public string StringQuery { get; set; }
        /// <summary>
        /// Hành động
        /// Write: Insert hoặc Update; Read - Đọc dữ liệu
        /// </summary>
        public string Action { get; set; }

        public object Parameter { get; set; }
    }
}
