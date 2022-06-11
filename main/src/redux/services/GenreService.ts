import axios from 'axios';
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModel";
import {Genre} from "../../models/GenreModel";

const API_URL = "http://localhost:8080/genres/";


class GenreService {
        getGenres(){
            return axios.get(API_URL + "get")
            .then((response) => {
                console.log(response.data);
                const data: Answer = response.data;
                const genres: Genre[] = data.answer.genres
                return genres;
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
}
export default new GenreService();