import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Client } from '../../models/ClientModel';

const API_URL = "http://localhost:8080/clients/";

class ClientService{

    editClient(user:Client){
        return axios.post(API_URL + "update",user,{headers:authHeader()})
        .then((response) => {
              const client: Client = response.data;
              localStorage.setItem('user', JSON.stringify(client));
              return client;
          })
          .catch((error) => {
            console.log(error);
            return user;
          });
    }

}
export default new ClientService();