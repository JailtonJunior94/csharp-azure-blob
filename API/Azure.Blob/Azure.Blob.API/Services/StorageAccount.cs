using System.IO;
using System.Linq;
using MimeMapping;
using Azure.Storage.Blobs;
using Azure.Blob.API.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;

namespace Azure.Blob.API.Services
{
    public class StorageAccount : IStorageAccount
    {
        private readonly string _container;
        private readonly string _connectionString;

        public StorageAccount(IConfiguration configuration)
        {
            _container = configuration["StorageAccount:ContainerName"];
            _connectionString = configuration["StorageAccount:ConnectionString"];
        }

        public IEnumerable<UploadResponse> Upload(UploadRequest request)
        {
            var list = new List<UploadResponse>();

            request.Files.ForEach(async file =>
            {
                string contentType = MimeUtility.GetMimeMapping(file.FileName);
                string extension = Path.GetExtension(file.FileName);

                var content = ToByteArray(file);
                string subs = Guid.NewGuid().ToString().Substring(0, 4);
                string fileName = $"{subs}-{request.Ticket}-{file.FileName}";

                var blobClient = new BlobClient(_connectionString, $"{_container}/{request.Ticket}", fileName);

                list.Add(new UploadResponse
                {
                    NomeArquivo = fileName,
                    Url = blobClient.Uri.AbsoluteUri,
                    ContentType = contentType,
                    Extension = extension
                });

                using var stream = new MemoryStream(content);
                await blobClient.UploadAsync(stream);
            });

            return list;
        }

        public IEnumerable<DownloadResponse> Downloads(string ticket)
        {
            var containerClient = new BlobContainerClient(_connectionString, $"{_container}");
            var response = containerClient.GetBlobs(prefix: $"{ticket}/").Select(j => new DownloadResponse
            {
                NomeArquivo = j.Name.Replace($"{ticket}/", ""),
                Url = $"{containerClient.Uri.AbsoluteUri}/{j.Name}"
            });

            return response;
        }

        private byte[] ToByteArray(IFormFile file)
        {
            byte[] content = new byte[0];
            if (file.Length > 0)
            {
                using var ms = new MemoryStream();

                file.CopyTo(ms);
                content = ms.ToArray();
            }
            return content;
        }
    }
}
