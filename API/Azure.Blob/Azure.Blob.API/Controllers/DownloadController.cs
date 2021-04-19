using Azure.Blob.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Blob.API.Controllers
{
    [Route("api/v1")]
    public class DownloadController : Controller
    {
        private readonly IStorageAccount _storageAccount;

        public DownloadController(IStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
        }

        [HttpGet("{ticket}/download")]
        public IActionResult DownLoadAsync(string ticket)
        {
            var response = _storageAccount.Downloads(ticket);
            return Ok(response);
        }
    }
}
