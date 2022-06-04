import { Film } from "./FilmModel"
export interface Seance{
	ID: number
	CinemaHall:{HallNumber:number,HallName: string},
	Film: Film
	SeanceDate:Date,
    BoughtSeats: {ID:number,SeatNumber:number}[]
    ReservedSeats: {ID:number,SeatNumber:number}[]
}