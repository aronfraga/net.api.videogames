using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using videogames_api.Models;
using videogames_api.Utils;
using videogames_api.Services;

namespace videogames_api.Controllers {
    
    [Route("[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase {
        
        public readonly VideogamesContext _dbcontext;
        VideogameService services = new VideogameService();
        Messages FinalResponse = new Messages();
        DataChecker check = new DataChecker();

        public VideogameController(VideogamesContext dbcontext){
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllItems(){
            try {
                var videogamesDB = _dbcontext.Videogames.Include(data => data.Genres).Include(data => data.Platforms).ToList();
                var videogamesAPI = services.GetAllDataApi();
                return FinalResponse.Succesful(new { videogamesDB, videogamesAPI });
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
