import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Film} from "../../models/FilmModel";

const API_URL = "http://localhost:8080/films/";


class FilmService {
        getFilms(){
            return axios.get(API_URL)
            .then((response) => {
                  const films: Film[] = response.data
                  return films;
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
        filterFilms(title:string,option:number,genre:string,restriction:number,minDuration:number,maxDuration:number){
          return axios.get(API_URL + "filter?title="+title+"&sort="+option+"&genre="+genre+"&restriction="+restriction+"&minDuration="+minDuration+"&maxDuration="+maxDuration)
          .then((response) => {
                const films: Film[] = response.data
                return films;
            })
            .catch((error) => {
              console.log(error);
              return []
            });
      }
        getFilmById(id: string) {
          return axios.get(API_URL+id)
            .then((response) => {
                const film : Film = response.data
                return film;
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
}
export default new FilmService();