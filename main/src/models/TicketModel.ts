import { Row } from "./RowModel";
import { Seat } from "./SeatModel";
import { SeanceHall } from "./SeanceModel";
import { Seance } from "./SeanceModel";

export interface Ticket {
	id: number,
	seance:Seance,
	row:Row| undefined,
	seat:Seat,
	dateTime: string,
}
export interface Tickets {
	id: number,
	seance:number,
	seat:Seat[],
	dateTime: string,
}