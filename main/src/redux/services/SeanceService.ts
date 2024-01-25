import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import {Seance, SeanceHall} from "../../models/SeanceModel";

const API_URL = "http://localhost:8080/seances/";

class SeanceService {
    getSeanceByFilmId(id: string) {
        return axios.get(API_URL + "film/"+id)
          .then((response) => {
              const seances : Seance[] = response.data;
              return seances;
          })
          .catch((error) => {
            console.log(error);
            return[];
          });
      }
      getSeanceById(id: string) {
        return axios.get(API_URL+id)
          .then((response) => {
              const seance : SeanceHall = response.data
              console.log(seance)
              return seance;
          })
          .catch((error) => {
            console.log(error);
            return;
          });
      }
}
export default new SeanceService();