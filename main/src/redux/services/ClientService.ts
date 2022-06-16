import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Client } from '../../models/ClientModel';

const API_URL = "http://localhost:8080/clients/";

class ClientService{

    editClient(data:Client){
        return axios.post(API_URL + "edit",data,{headers:authHeader()})
        .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              const client: Client = data.answer.client;
              localStorage.setItem('user', JSON.stringify(client));
              console.log(client);
              return data.status;
            }
            return data.status
          })
          .catch((error) => {
            console.log(error);
            return false;
          });
    }

}
export default new ClientService();