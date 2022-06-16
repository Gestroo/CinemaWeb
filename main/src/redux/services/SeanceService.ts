import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Seance, SeanceHall} from "../../models/SeanceModel";

const API_URL = "http://localhost:8080/seances/";

class SeanceService {
    getSeanceByFilmId(id: string) {
        return axios.get(API_URL + "filmId?id="+id)
          .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              const seances : Seance[] = data.answer.seances;
              return seances;
            }
            return[]
          })
          .catch((error) => {
            console.log(error);
            return[];
          });
      }
      getSeanceById(id: string) {
        return axios.get(API_URL + "id?id="+id)
          .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              const seance : SeanceHall = data.answer.seance
              console.log(seance)
              return seance;
            }
            return;
          })
          .catch((error) => {
            console.log(error);
            return;
          });
      }
}
export default new SeanceService();