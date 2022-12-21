using Microsoft.AspNetCore.Mvc;
using videogames_api.Models;

namespace videogames_api.Utils {
    public class Messages : ControllerBase {

        public object Succesful(List<Videogame> videogames) { 
            return StatusCode(200, new { request_status = "unsuccessful", response =  videogames });
        }

        public object Succesful(string message){
            return StatusCode(200, new { request_status = "unsuccessful", response = message });
        }

        public object Unsuccesful(string message) {
            return StatusCode(400, new { request_status = "unsuccessful", response = message });
        }
    }
}
