import {Client} from "../../models/ClientModel";
import axios from "axios";
import {Training} from "../../models/TrainingModel";
import authHeader from "../AuthHeader";

const API_URL = "http://localhost:8080/training/";
class TrainingService{
    getClientTraining(user:Client){
        return axios.get(API_URL, {headers:authHeader()})
            .then((response)=>{
                const train: boolean = response.data;
                return train;
            })
            .catch((error)=>{
                console.log(error);
                return false
            })
    }
    updateTraining(user:Client){
        return axios.post(API_URL, {header:authHeader()})
            .then((response)=>{
                const training:Training = response.data;
                return training;
            })
            .catch((error)=>{
                console.log(error);
                return null
            })
    }
}