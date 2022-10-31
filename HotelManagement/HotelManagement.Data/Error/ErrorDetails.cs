using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Error
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string title { get; set; }
        public  DateTime createdDate { get; set; }


    }
    public static class ErrorManage
    {
        public static string Show(string message)
        {
            var errorDetails = new ErrorDetails
            {
                statusCode = 404,
                message = message,
                title = "Object not found",
                createdDate = DateTime.Now  
            };
            return JsonConvert.SerializeObject(errorDetails);
        }
    }
   

}
