using System.Threading.Tasks;
using TripSity.Model;
using Azure.Storage.Blobs;

namespace TripSity.AzureBlob
{
    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-file");

            var blobClient = blobContainer.GetBlobClient(model.CsvFile.FileName);

            await blobClient.UploadAsync(model.CsvFile.OpenReadStream());
        }
    }
}
