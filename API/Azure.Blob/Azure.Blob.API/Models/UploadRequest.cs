using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Azure.Blob.API.Models
{
    public class UploadRequest
    {
        public List<IFormFile> Files { get; set; }
        public string Ticket { get; set; }
    }
}
