import {Seat} from "./SeatModel";

export interface Row {

    id: number,
    rowNumber: number,
    seats: Seat[]
}