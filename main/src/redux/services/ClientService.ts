import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Client } from '../../models/ClientModel';

const API_URL = "http://localhost:8080/clients/";

class ClientService{

    editClient(user:Client){
        return axios.post(API_URL + "edit",user,{headers:authHeader()})
        .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              const client: Client = data.answer.client;
              localStorage.setItem('user', JSON.stringify(client));
              console.log(client);
              return client;
            }
            return user
          })
          .catch((error) => {
            console.log(error);
            return user;
          });
    }

}
export default new ClientService();