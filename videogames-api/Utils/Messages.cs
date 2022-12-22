using Microsoft.AspNetCore.Mvc;
using videogames_api.Models;

namespace videogames_api.Utils {
    public class Messages : ControllerBase {

        public IActionResult Succesful(List<Videogame> videogames) { 
            return StatusCode(200, new { request_status = "successful", response =  videogames });
        }

        public IActionResult Succesful(List<Genre> genre){
            return StatusCode(200, new { request_status = "successful", response = genre });
        }

        public IActionResult Succesful(List<Platform> platforms){
            return StatusCode(200, new { request_status = "successful", response = platforms });
        }

        public IActionResult Succesful(string message){
            return StatusCode(200, new { request_status = "successful", response = message });
        }

        public IActionResult Unsuccesful(string message) {
            return StatusCode(400, new { request_status = "unsuccessful", response = message });
        }
    }
}
