import { Row } from "./RowModel";
import { Seat } from "./SeatModel";
import { Seance } from "./SeanceModel";

export interface Ticket {
	ID: number,
	Seance:Seance,
	Row:Row,
	Seat:Seat,
	DateTime: string,
}