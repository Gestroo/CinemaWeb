export interface Client {
	id: number
	lastname: string,
	firstname: string,
	middlename: string | undefined,
	email: string,
	phone: string,
	login: string,
	avatar: string | undefined
}