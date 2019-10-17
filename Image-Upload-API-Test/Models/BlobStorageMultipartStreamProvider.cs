using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Image_Upload_API_Test.Models {

    public class BlobStorageMultipartStreamProvider : MultipartStreamProvider {

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers) {

            Stream stream = null;
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;

            if(contentDisposition != null) {

                if(!string.IsNullOrWhiteSpace(contentDisposition.FileName)) {

                    string connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];
                    string container = ConfigurationManager.AppSettings["Container"];

                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(contentDisposition.FileName);
                    stream=blob.OpenWrite();

                }

            }

            return stream;

        }

    }

}