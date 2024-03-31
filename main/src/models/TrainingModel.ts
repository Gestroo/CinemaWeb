import {Client} from "./ClientModel";

export interface Training{
    id:number,
    flag:boolean,
    lastTrain:string,
    client:Client
}