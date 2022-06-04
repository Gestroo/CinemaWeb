export interface Film{
	ID: number
	Name: string,
	Duration: number,
	Restriction: number,
    Description: string | null,
	Genre: {ID:number,Title:string, Description:string| undefined}
	Poster: string | undefined
}