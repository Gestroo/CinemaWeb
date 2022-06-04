import axios from 'axios';
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModel";
import {removeCookie, setCookie} from "typescript-cookie";
import {RegisterSuccess, RegisterFail, LoginSuccess, LoginFail, Logout} from "../actions/authActions"
import {Film} from "../../models/FilmModel";
import {clientActions} from "../slices/clientslice";

const API_URL = "http://localhost:8080/films/";


class FilmService {
        getFilms(){
            return axios.get(API_URL + "get")
            .then((response) => {
                console.log(response.data);
                const data: Answer = response.data;
                const films: Film[] = data.answer.films
                return films;
              })
              .catch((error) => {
                console.log(error);
                return []
              });
        }
        getFilmById(id: string) {
          return axios.post(API_URL + "id", id)
            .then((response) => {
              const data: Answer = response.data;
              const film : Film = data.answer.film
              return film;
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
}
export default new FilmService();