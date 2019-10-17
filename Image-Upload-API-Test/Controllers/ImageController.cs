using Image_Upload_API_Test.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Image_Upload_API_Test.Controllers {

    [EnableCors(origins: "*", headers: "*", methods:"*")]
    public class ImageController : ApiController {

        [Route("api/image")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostImage() {

            HttpResponseMessage response;

            if(!Request.Content.IsMimeMultipartContent()) {

                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Unsupported request type. Must have a file.");

            }

            try {

                MultipartStreamProvider provider = new BlobStorageMultipartStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                response = Request.CreateResponse(HttpStatusCode.OK, "File uploaded successfully.");

            } catch(Exception err) {

                response = Request.CreateResponse(HttpStatusCode.InternalServerError, err.Message);

            }

            return response;

        }

    }

}
