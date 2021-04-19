using Azure.Blob.API.Models;
using Azure.Blob.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Blob.API.Controllers
{
    [Route("api/v1")]
    public class UploadController : Controller
    {
        private readonly IStorageAccount _storageAccount;

        public UploadController(IStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromForm] UploadRequest request)
        {
            var response = _storageAccount.Upload(request);
            return Ok(response);
        }
    }
}
