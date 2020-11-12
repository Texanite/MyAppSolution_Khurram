using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebServices.Extensions
{
    public static class ServicesExtension
    {
        public static ResultDto SuccessfulResult(dynamic data)
        {
            var result = new ResultDto
            {
                Ok = true,
                Data = data,
                Error = "No"
            };

            return result;
        }

        public static ResultDto ErrorResult(Exception exp)
        {
            var result = new ResultDto
            {
                Ok = false,
                Data = exp,
                Error = exp.Message

            };

            return result;
        }
    }
}
