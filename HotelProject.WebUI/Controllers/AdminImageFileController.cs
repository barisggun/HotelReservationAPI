using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); //dosya yükleme işlemi
            await file.CopyToAsync(stream); //dosyayı ilgili akış üzerinden kopyalayacağız 
            var bytes = stream.ToArray(); 

            //akışı oluştur, dosyayı kopyala, akıştaki dosyayı byte olarak tut. byte dizisini aşağıda tekrar kullanacağız.

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            
            await httpClient.PostAsync("http://localhost:5242/api/FileImage", multipartFormDataContent);

            return View();

        }

    }
}
