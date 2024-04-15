using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.Results
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(){ }

        public GenericCommandResult(bool success, string message, object data, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public bool Success {get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode {get; set;}
    }
}