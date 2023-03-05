using Info.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// https://educathub.com/c-tercih-nedenleri-ve-gelecegi/#:~:text=C%23%20%2C%20web%20servis%20uygulamalar%C4%B1%20i%C3%A7in%20olduk%C3%A7a%20tercih%20edilir.&text=G%C3%BCn%C3%BCm%C3%BCzde%20oyun%20tasarlaman%C4%B1n%20temenlinde%20C%23,pop%C3%BCler%20her%20oyunun%20teknik%20taraf%C4%B1d%C4%B1r.

namespace Info.Api.Controllers
{
    [Route("api/Kisi")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private static List<Kisi> kisiler = new List<Kisi>
        {
            new Kisi{Id=1, Adi="Olya"},
            new Kisi{Id=2, Adi="Sinem"},
            new Kisi{Id=3, Adi="Berkay"}
        };


        [HttpGet]
        public IEnumerable<Kisi> Get()
        {
            return kisiler;
        }

        [HttpGet("{id}")]
        public ActionResult<Kisi?> Get(int id)
        {
            /*
            //int[] sayilar1 = { 12, 45, 6, 8 };
            ////sayilarq.add() /// Yok
            //List<int> sayilar2 = new List<int>();
            //sayilar2.Add(1);
            ////eklenebiliyor
            */

            var data = kisiler.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return NoContent();

            return Ok(data);
        }

        [HttpPost]
        public ActionResult<Kisi?> Ekle(Kisi kisi)
        {
            kisiler.Add(kisi);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Kisi?> Güncelle(int id, Kisi model)
        {
            if (id != model.Id)
                return BadRequest();
            var kisi = kisiler.FirstOrDefault(x=> x.Id == id);
            if (kisi == null)
                return NotFound();


            kisi.Adi=model.Adi;      
            
            return Ok();
        }
    }
}
