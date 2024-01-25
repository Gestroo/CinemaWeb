import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import { Booking } from '../../models/BookingModel';
import authHeader from '../AuthHeader';

const API_URL = "http://localhost:8080/bookings/";


class BookingService {
        getBookingsByClientId() {
          return axios.get(API_URL + "get",{headers:authHeader()})
            .then((res) => {
                const bookings : Booking[] = res.data
                console.log(bookings)
                return bookings;
            })
            .catch((error) => {
              console.log(error);
              return [];
            });
        }
        filterBookings(option:number){
          return axios.get(API_URL + "filter?sort="+option,{headers:authHeader()})
          .then((res) => {
                const bookings: Booking[] = res.data
                return bookings;
            })
            .catch((error) => {
              console.log(error);
              return []
            });
      }
        getBookingById(id: string) {
          return axios.get(API_URL +id,{headers:authHeader()})
            .then((res) => {
                const booking : Booking = res.data
                return booking;
            })
            .catch((error) => {
              console.log(error);
              return ;
            });
        }
}
export default new BookingService();