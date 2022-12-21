using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using videogames_api.Models;
using videogames_api.Utils;

namespace videogames_api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase {
        public readonly VideogamesContext _dbcontext;
        Messages FinalResponse = new Messages();

        public GenreController(VideogamesContext dbcontext){
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            List<Genre> genre = new List<Genre>();
            try {
                genre = _dbcontext.Genres.ToList();
                if (genre == null) return BadRequest("there isn't genres saved, save one for show it");
                return FinalResponse.Succesful(genre);
            } catch (Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOne([FromBody] Genre item){
            try {
                _dbcontext.Genres.Add(item);
                _dbcontext.SaveChanges();
                return FinalResponse.Succesful("Genre was created");
            } catch (Exception ex) {
                return FinalResponse.Unsuccesful(ex.Message);
            }
        }
    }
}
