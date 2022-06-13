import { Client } from "./ClientModel";
import { Ticket } from "./TicketModel";

export interface Booking{
    ID:number,
    DateTime:string,
    Ticket:Ticket,
    Client: Client,
    IsBought:boolean,
}