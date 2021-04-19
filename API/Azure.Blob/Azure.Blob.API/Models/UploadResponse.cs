namespace Azure.Blob.API.Models
{
    public class UploadResponse
    {
        public string NomeArquivo { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}
