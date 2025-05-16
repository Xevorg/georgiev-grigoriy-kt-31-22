using System.Net;

namespace georgiev_grigoriy_kt_31_22.Helpers
{
    public class ApiException : Exception
    {
        public int StatusCode { get; }
        public ApiException(string msg, HttpStatusCode code)
            : base(msg) => StatusCode = (int)code;
    }
}