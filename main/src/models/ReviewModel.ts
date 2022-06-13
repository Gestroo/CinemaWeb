import { Client } from "./ClientModel";
import { Film } from "./FilmModel";

export interface Review{
    ID:number,
    Film: Film,
    Client:Client,
    Rating:number,
    Comment:string,
}