import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import { Booking } from '../../models/BookingModel';
import authHeader from '../AuthHeader';

const API_URL = "http://localhost:8080/bookings/";


class BookingService {
        getBookingsByClientId() {
          return axios.get(API_URL + "get",{headers:authHeader()})
            .then((response) => {
              const data: Answer = response.data;
             if (data.status){
                const bookings : Booking[] = data.answer.bookings
                console.log(bookings)
                return bookings;
             }
             return []
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
        getBookingById(id: string) {
          return axios.get(API_URL + "id?id="+id,{headers:authHeader()})
            .then((response) => {
              const data: Answer = response.data;
              if (data.status){
                const booking : Booking = data.answer.booking
                console.log(booking)
                return booking;
              } 
              return;
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
}
export default new BookingService();