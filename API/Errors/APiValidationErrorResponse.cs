using System.Collections.Generic;

namespace API.Errors
{
    public class APiValidationErrorResponse : ApiResponse
    {
        public APiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}