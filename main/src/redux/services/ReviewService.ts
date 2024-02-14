import axios from 'axios';
import {Answer} from "../../models/RequestModel";
import authHeader from '../AuthHeader';
import { Client } from '../../models/ClientModel';
import { PostReview, Review } from '../../models/ReviewModel';
import NewReview from '../../components/Review';

const API_URL = "http://localhost:8080/reviews/";

class ReviewService{

    AddReview(data:Review){
      console.log(data)
        return axios.post(API_URL,data,{headers:authHeader()})
        .then((response) => {
              return response.data;
          })
          .catch((error) => {
            console.log(error);
            return false;
          });
    }
    filterReviews(option:number){
      return axios.get(API_URL + "filter?sort="+option,{headers:authHeader()})
      .then((response) => {
            const reviews: Review[] = response.data
            return reviews;
        })
        .catch((error) => {
          console.log(error);
          return []
        });
  }
    getReviewsByClientId() {
      return axios.get(API_URL,{headers:authHeader()})
        .then((response) => {

            const reviews : Review[] = response.data
            console.log(reviews)
            return reviews;

        })
        .catch((error) => {
          console.log(error);
          return [];
        });
    }
}
export default new ReviewService();