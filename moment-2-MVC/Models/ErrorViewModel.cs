using System;

namespace moment_2_MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }


        public static string message;
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
