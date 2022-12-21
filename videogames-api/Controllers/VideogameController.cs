using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using videogames_api.Models;
using videogames_api.Utils;

namespace videogames_api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase {
        public readonly VideogamesContext _dbcontext;
        Messages FinalResponse = new Messages();
        
        public VideogameController(VideogamesContext dbcontext){
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllItems(){
            List<Videogame> videogames = new List<Videogame>();
            try {
                videogames = _dbcontext.Videogames.Include(data => data.Genre).Include(data => data.Platforms).ToList();
                return (IActionResult)FinalResponse.Succesful(videogames);
            } catch(Exception ex) {
                return (IActionResult)FinalResponse.Unsuccesful(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOne([FromBody] Videogame item){
            try {
                _dbcontext.Videogames.Add(item);
                _dbcontext.SaveChanges();
                return (IActionResult)FinalResponse.Succesful("Videogame was created");
            } catch (Exception ex) {
                return (IActionResult)FinalResponse.Unsuccesful(ex.Message);
            }
        }

    }
}
