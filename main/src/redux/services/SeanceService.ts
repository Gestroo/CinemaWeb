import axios from 'axios';
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModel";
import {removeCookie, setCookie} from "typescript-cookie";
import {Seance} from "../../models/SeanceModel";

const API_URL = "http://localhost:8080/seances/";

class SeanceService {
    getSeanceById(id: string) {
        return axios.post(API_URL + "id", id)
          .then((response) => {
            const data: Answer = response.data;
            const seances : Seance[] = data.answer.seances;
            return seances;
          })
          .catch((error) => {
            console.log(error);
            return[];
          });
      }
}
export default new SeanceService();