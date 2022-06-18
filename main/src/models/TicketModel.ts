import { Row } from "./RowModel";
import { Seat } from "./SeatModel";
import { SeanceHall } from "./SeanceModel";
import { Seance } from "./SeanceModel";

export interface Ticket {
	ID: number,
	Seance:Seance,
	Row:Row| undefined,
	Seat:Seat,
	DateTime: string,
}
export interface Tickets {
	ID: number,
	Seance:number,
	Seat:Seat[],
	DateTime: string,
}