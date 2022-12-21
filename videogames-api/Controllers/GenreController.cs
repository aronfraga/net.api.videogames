using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult CreateOne([FromBody] Genre item){
            try {
                _dbcontext.Genres.Add(item);
                _dbcontext.SaveChanges();
                return (IActionResult)FinalResponse.Succesful("Genre was created");
            } catch (Exception ex) {
                return (IActionResult)FinalResponse.Unsuccesful(ex.Message);
            }
        }
    }
}
