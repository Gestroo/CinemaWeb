import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Genre} from "../../models/GenreModel";

const API_URL = "http://localhost:8080/genres/";


class GenreService {
        getGenres(){
            return axios.get(API_URL + "get")
            .then((response) => {
                console.log(response.data);
                const data: Answer = response.data;
                if (data.status){
                  const genres: Genre[] = data.answer.genres
                  return genres;
                }
                return []
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
}
export default new GenreService();