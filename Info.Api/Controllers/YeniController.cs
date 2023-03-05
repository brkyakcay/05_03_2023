using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Info.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeniController : ControllerBase
    {
        [HttpGet]
        public string Hi()
        {
            return "Merhaba";
        }
        //https://www.restapitutorial.com/lessons/httpmethods.html
        [HttpPost]
        public string Hi(string Adi)
        {
            return "Merhaba"+Adi;
        }

        [HttpGet("selamlar/{kisiSayisi}")]
        public string Hi(int kisiSayisi)
        {
            string res = "";
            for (int i = 0; i < kisiSayisi; i++)
            {
                res += "Merhabalar, ";
            }
            return res; 
        }

        [HttpGet("selamlar/{kisiSayisi}/hi/{adi}")]
        public string Hi(int kisiSayisi, string adi)
        {
            string res = "";
            for (int i = 0; i < kisiSayisi; i++)
            {
                res += $"Merhabalar, {adi} ";
            }
            return res;
        }
    }
}
