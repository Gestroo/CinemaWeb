import { Genre } from "./GenreModel"

export interface Film{
	ID: number,
	Name: string,
	Duration: number,
	Genre: Genre,
	Restriction: number,
    Description: string | null,
	Poster: string | undefined
}