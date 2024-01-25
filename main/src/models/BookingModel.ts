import { Client } from "./ClientModel";
import { Ticket } from "./TicketModel";

export interface Booking{
    id:number,
    dateTime:string,
    ticket:Ticket,
    client: Client,
    isBought:boolean,
}