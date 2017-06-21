using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.App_Data
{
    public class ResponseResult 
    {
        private object result;

        public object Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
    }
}