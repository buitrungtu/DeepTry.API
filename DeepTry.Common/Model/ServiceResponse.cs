using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class ServiceResponse
    {
        // <summary>
        /// Thông báo
        /// </summary>
        public List<string> Message { get; set; } = new List<string>();

        /// <summary>
        /// Mã lỗi nội bộ
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Thành công
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object Data { get; set; }
    }
}
