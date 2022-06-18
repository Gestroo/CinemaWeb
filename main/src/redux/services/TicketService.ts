import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Tickets } from '../../models/TicketModel';
import { PostReview, Review } from '../../models/ReviewModel';

const API_URL = "http://localhost:8080/tickets/";

class TicketService{

    BookTicket(data:Tickets){
        return axios.post(API_URL + "book",data,{headers:authHeader()})
        .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              return data.status;
            }
            return data.status
          })
          .catch((error) => {
            console.log(error);
            return false;
          });
    }
    BuyTicket(data:Tickets){
        return axios.post(API_URL + "buy",data,{headers:authHeader()})
        .then((response) => {
            const data: Answer = response.data;
            if (data.status){
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
export default new TicketService();