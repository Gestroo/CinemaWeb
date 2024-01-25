import { Genre } from "./GenreModel"

export interface Film{
	id: number,
	name: string,
	duration: number,
	genre: Genre,
	restriction: number,
    description: string | null,
	poster: string | undefined
}