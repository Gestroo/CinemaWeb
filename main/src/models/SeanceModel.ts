import { Film } from "./FilmModel"
import { Hall } from "./HallModel"
export interface Seance{
	ID: number
	CinemaHall:{HallNumber:number,HallName: string},
	Film: Film,
	SeanceDate:string,
	SeanceTime:string,
	Cost:number,
}
export interface SeanceHall extends Seance{
	CinemaHall:Hall
	BoughtSeats: {ID:number,SeatNumber:number}[],
    ReservedSeats: {ID:number,SeatNumber:number}[],
}