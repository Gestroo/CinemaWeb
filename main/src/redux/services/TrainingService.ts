import {Client} from "../../models/ClientModel";
import axios from "axios";
import {Training} from "../../models/TrainingModel";
import authHeader from "../AuthHeader";

const API_URL = "http://localhost:8080/training/";

class TrainingService {
    getClientTraining() {
        return axios.get(API_URL, {headers: authHeader()})
            .then((response) => {
                const train: boolean = response.data.flag;
                console.log(train)
                return !train;
            })
            .catch((error) => {
                console.log(error);
                return false
            })
    }

    updateTraining(user: Client) {
        return axios.post(API_URL, {header: authHeader()})
            .then((response) => {
                const training: Training = response.data;
                return training;
            })
            .catch((error) => {
                console.log(error);
                return null
            })
    }

    steps = [
        {
            element: '#films',
            intro: 'Выберите один из фильмов',
            position: 'right',
        },
        {
            element: '#seances',
            intro: 'Выберите один из сеансов',
            position: 'right',
        },{
            element: '#hall',
            intro: 'Выберите место в соответствии с легендой',
            position: 'right',
        },
        {
            element: '#buy',
            intro: 'Нажмите на кнопку "Купить" ',
            position: 'right',
        },
        {
            element: '#confirm',
            intro: 'Нажмите на кнопку "Оплатить" ',
            position: 'right',
        }
    ];
}

export default new TrainingService()