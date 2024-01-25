import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Genre} from "../../models/GenreModel";

const API_URL = "http://localhost:8080/genres/";


class GenreService {
        getGenres(){
            return axios.get(API_URL)
            .then((response) => {
                  const genres: Genre[] = response.data
                  return genres;
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
}
export default new GenreService();