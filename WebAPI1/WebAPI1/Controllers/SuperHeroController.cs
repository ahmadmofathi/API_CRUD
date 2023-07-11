using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase {
        private static List<SuperHero> Heros = new List<SuperHero> {
                    new SuperHero
                    {
                        id = 1,
                        name = "Spider Man",
                        fname = "Peter",
                        lname = "Barker",
                        city = "NYC"
                    },
                    new SuperHero
                    {
                        id = 2,
                        name = "Iron Man",
                        fname = "Tony",
                        lname = "Starck",
                        city = "Malibu"
                    }
            };

        [HttpGet]

        public ActionResult<List<SuperHero>> GetAll()
        {
            return Ok(Heros);
        }

        [HttpGet("{id}")]

        public ActionResult<SuperHero> GetById(int id)
        {
            SuperHero? hero = Heros.FirstOrDefault(x=>x.id==id);
            if(hero is null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public ActionResult Add(SuperHero newHero)
        {
            newHero.id = Heros.Count() +1;
            Heros.Add(newHero);
            return Ok();
        }

        [HttpPut("{id}")]
     
        public ActionResult Update(SuperHero newHero,int id) { 
            if(id != newHero.id)
            {
                return BadRequest();
            }
            SuperHero? heroEdit = Heros.FirstOrDefault(x => x.id==id);
            if (heroEdit is null)
            {
                return NotFound();
            }
            heroEdit.fname = newHero.fname;
            heroEdit.lname=newHero.lname;
            heroEdit.name=newHero.name;
            heroEdit.city=newHero.city;
            return Ok();
         }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            SuperHero? heroDelete = Heros.FirstOrDefault(x => x.id == id);
            if (heroDelete is null)
            {
                return NotFound();
            }
            Heros.Remove(heroDelete);
            return Ok();
        }
     }
}
 
