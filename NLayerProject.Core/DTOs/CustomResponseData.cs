using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerProject.Core.DTOs
{
    public class CustomResponseData<T> 
    {
        public T Data { get; set; }



        [JsonIgnore] //clientın görmesini engeller
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseData<T> Success(int statusCode, T data)
        {
            return new CustomResponseData<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseData<T> Success(int statusCode)
        {
            return new CustomResponseData<T> { StatusCode = statusCode };
        }
        public static CustomResponseData<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseData<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseData<T> Fail(int statusCode, string error)
        {
            return new CustomResponseData<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }


    }
}
