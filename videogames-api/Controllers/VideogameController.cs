using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using videogames_api.Models;
using videogames_api.Utils;

namespace videogames_api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase {
        public readonly VideogamesContext _dbcontext;
        Messages FinalResponse = new Messages();
        DataChecker check = new DataChecker();

        public VideogameController(VideogamesContext dbcontext){
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllItems(){
            List<Videogame> videogames = new List<Videogame>();
            try {
                videogames = _dbcontext.Videogames.ToList();
                return FinalResponse.Succesful(videogames);
            } catch(Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOne([FromBody] Videogame item){
            try {
                check.VideogameCheck(item);
                _dbcontext.Videogames.Add(item);
                _dbcontext.SaveChanges();
                return FinalResponse.Succesful("Videogame was created");
            } catch (Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }

    }
}
