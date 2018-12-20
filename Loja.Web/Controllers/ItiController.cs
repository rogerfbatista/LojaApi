using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Loja.Web.Controllers
{
    public class ItiController : ApiController
    {

        private readonly Application.Interfaces.IProdutoAppService _produtoAppService;


        public ItiController(Application.Interfaces.IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }


        // GET: api/Iti

        [HttpGet, Route("api/v1/Iti/{texto}")]
        public IEnumerable<object> ObterItiArquivo(string texto)
        {
            var lista = new List<object>();
            lista.Add(new { Arquivo = @"C:\Users\Bianca\Downloads\Boleto.pdf", Remetente = "rogerfbatista@gmail.com" });
            lista.Add(new { Arquivo = @"C:\Users\Bianca\Downloads\Topicos211111h.JPG", Remetente = "rogerfbatista@gmail.com" });

            return lista;
        }


        [HttpGet]
        public string Get(int id)
        {
            return string.Empty;
        }


        [HttpPost, Route("api/v1/Iti")]
        public HttpResponseMessage Download([FromBody]string arquivo)
        {
            try
            {
                //Check if the file exists. If the file doesn't exist, throw a file not found exception
                if (!System.IO.File.Exists(arquivo))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                //Copy the source file stream to MemoryStream and close the file stream
                MemoryStream responseStream = new MemoryStream();
                Stream fileStream = System.IO.File.Open(arquivo, FileMode.Open);

                fileStream.CopyTo(responseStream);
                fileStream.Close();
                responseStream.Position = 0;

                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.OK;

                //Write the memory stream to HttpResponseMessage content
                response.Content = new StreamContent(responseStream);
                string contentDisposition = string.Concat("attachment; filename=", "teste1");
                response.Content.Headers.ContentDisposition =
                              ContentDispositionHeaderValue.Parse(contentDisposition);
                return response;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }



    }
}
