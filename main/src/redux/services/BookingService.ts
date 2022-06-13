import axios from 'axios';
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModel";
import {removeCookie, setCookie} from "typescript-cookie";
import {RegisterSuccess, RegisterFail, LoginSuccess, LoginFail, Logout} from "../actions/authActions"
import {Film} from "../../models/FilmModel";
import {clientActions} from "../slices/clientslice";
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
                return bookings;
              }
            })
            .catch((error) => {
              console.log(error);
              return;
            });
        }
}
export default new BookingService();