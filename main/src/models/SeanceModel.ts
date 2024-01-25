import { Film } from "./FilmModel"
import { Hall } from "./HallModel"
export interface Seance{
	id: number
	cinemaHall:{hallNumber:number,hallName: string},
	film: Film,
	seanceDate:string,
	seanceTime:string,
	cost:number,
}
export interface SeanceHall extends Seance{
	cinemaHall:Hall
	boughtSeats: {id:number,seatNumber:number}[],
    reservedSeats: {id:number,seatNumber:number}[],
}