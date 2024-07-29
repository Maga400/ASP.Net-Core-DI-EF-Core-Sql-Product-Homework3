using System;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
