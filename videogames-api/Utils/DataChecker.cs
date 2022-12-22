using videogames_api.Models;

namespace videogames_api.Utils {
    public class DataChecker {
        public void NameCheck(Platform item){
            if (item.Name == null || item.Name is not String) 
                throw new ArgumentException("The Platform property name can not be empty and must be a string type...");
        }

        public void NameCheck(Genre item){
            if (item.Name == null || item.Name is not String) 
                throw new ArgumentException("The Genre property name can not be empty and must be a string type...");
        }

        public void VideogameCheck(Videogame item){
            if (item.Name == null || item.Name is not String) 
                throw new ArgumentException("The property name can not be empty and must be a string...");
            if (item.Description == null || item.Description is not String) 
                throw new ArgumentException("The property description can not be empty and must be a string...");
            if (item.ReleaseDate == null || item.ReleaseDate is not String) 
                throw new ArgumentException("The property Release Date can not be empty and must be a string...");
            if (item.Image == null || item.Image is not String) 
                throw new ArgumentException("The property Release Date can not be empty and must be a string...");
            if (item.Rating == null || item.Rating is not int) 
                throw new ArgumentException("The property Release Date can not be empty and must be a Number...");
            //if (item.IdPlatform == null) 
              //  throw new ArgumentException("The property Platforms can not be empty and must be a id of platform...");
            //if (item.IdGenre == null) 
              //  throw new ArgumentException("The property Genre can not be empty and must be a id of genre...");
        }
    }
}
