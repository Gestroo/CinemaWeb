import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Client } from '../../models/ClientModel';
import { PostReview, Review } from '../../models/ReviewModel';
import NewReview from '../../components/Review';

const API_URL = "http://localhost:8080/reviews/";

class ReviewService{

    AddReview(data:PostReview){
        return axios.post(API_URL + "add",data,{headers:authHeader()})
        .then((response) => {
            const data: Answer = response.data;
            if (data.status){
              const review: PostReview = data.answer.review;
              return data.status;
            }
            return data.status
          })
          .catch((error) => {
            console.log(error);
            return false;
          });
    }
    getReviewsByClientId() {
      return axios.get(API_URL + "get",{headers:authHeader()})
        .then((response) => {
          const data: Answer = response.data;
         if (data.status){
            const reviews : Review[] = data.answer.reviews
            console.log(reviews)
            return reviews;
         }
         return []
        })
        .catch((error) => {
          console.log(error);
          return;
        });
    }
}
export default new ReviewService();