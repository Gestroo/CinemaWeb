import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Film} from "../../models/FilmModel";

const API_URL = "http://localhost:8080/films/";


class FilmService {
        getFilms(){
            return axios.get(API_URL + "get")
            .then((response) => {
                console.log(response.data);
                const data: Answer = response.data;
                if (data.status){
                  const films: Film[] = data.answer.films
                  return films;
                }
                return []
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
        filterFilms(title:string,option:number,genre:string,restriction:number,minDuration:number,maxDuration:number){
          return axios.get(API_URL + "filter?title="+title+"&option="+option+"&genre="+genre+"&restriction="+restriction+"&minDuration="+minDuration+"&maxDuration="+maxDuration)
          .then((response) => {
              console.log(response.data);
              const data: Answer = response.data;
              if (data.status){
                const films: Film[] = data.answer.films
                return films;
              }
              return []
            })
            .catch((error) => {
              console.log(error);
              return []
            });
      }
        getFilmById(id: string) {
          return axios.get(API_URL + "id?id="+id)
            .then((response) => {
              const data: Answer = response.data;
              if (data.status){
                const film : Film = data.answer.film
                return film;
              }
              return;
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
}
export default new FilmService();