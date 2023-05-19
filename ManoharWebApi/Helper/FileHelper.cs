using Azure.Storage.Blobs;
using ManoharWebApi.Model;
using Microsoft.AspNetCore.Http;

namespace ManoharWebApi.Helper
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {


            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shopifymartapplication;AccountKey=Yp39fujqWao3B7uLdO8bQ3dSrhl5zUaQ9eW+kyB4IDhwfcjbAOGnKgxQSH0hDd2i8H5HpE3lnHQP+ASt00yAbw==;EndpointSuffix=core.windows.net";
            string containerName = "bookphotos";

            BlobContainerClient containerCLient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerCLient.GetBlobClient(file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
        return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadUrl(IFormFile file)
        {


            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shopifymartapplication;AccountKey=Yp39fujqWao3B7uLdO8bQ3dSrhl5zUaQ9eW+kyB4IDhwfcjbAOGnKgxQSH0hDd2i8H5HpE3lnHQP+ASt00yAbw==;EndpointSuffix=core.windows.net";
            string containerName = "bookurl";

            BlobContainerClient containerCLient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerCLient.GetBlobClient(file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
