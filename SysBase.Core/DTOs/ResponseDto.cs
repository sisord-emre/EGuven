﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.DTOs
{
    //apilerden dönen response istekleri için
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]//api tarafına dönemesini istemiyoruz
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }
        public static ResponseDto<T> Success(int statusCode, T data)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = data };
        }
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(int statusCode, String error)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
        public static ResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
    }
}
