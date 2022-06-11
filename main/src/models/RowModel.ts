export interface Row{

   ID:number,
    RowNumber: number,
    Seats:{ID:number,
        SeatNumber:number,
        Status:string,
        }[]
    }