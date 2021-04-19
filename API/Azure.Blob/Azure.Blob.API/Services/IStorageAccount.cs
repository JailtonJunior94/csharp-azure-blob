using Azure.Blob.API.Models;
using System.Collections.Generic;

namespace Azure.Blob.API.Services
{
    public interface IStorageAccount
    {
        IEnumerable<DownloadResponse> Downloads(string ticket);
        IEnumerable<UploadResponse> Upload(UploadRequest request);
    }
}
