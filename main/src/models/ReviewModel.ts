import { Client } from "./ClientModel";
import { Film } from "./FilmModel";

export interface Review{
    id:number,
    film: Film,
    client:Client,
    rating:number,
    comment:string,
}
export interface PostReview{
    film: Film,
    client:Client,
    rating:number,
    comment:string,
}