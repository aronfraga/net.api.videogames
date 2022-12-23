using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using videogames_api.Models;
using videogames_api.Utils;

namespace videogames_api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase {
        public readonly VideogamesContext _dbcontext;
        Messages FinalResponse = new Messages();
        DataChecker check = new DataChecker();

        public PlatformController(VideogamesContext dbcontext){
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllItems(){
            List<Platform> platforms = new List<Platform>();
            try {
                platforms = _dbcontext.Platforms.ToList();
                if (platforms == null) return BadRequest("There isn't genres saved, save one for show it");
                return FinalResponse.Succesful(platforms);
            } catch (Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOne([FromBody] Platform item){
            try {
                check.NameCheck(item);
                _dbcontext.Platforms.Add(item);
                _dbcontext.SaveChanges();
                return FinalResponse.Succesful("Platform was created");
            } catch (Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }
    }
}
