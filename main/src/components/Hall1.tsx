import React from 'react';
import {Button, Card} from 'react-bootstrap';
import {Seance, SeanceHall} from '../models/SeanceModel'
import {useNavigate, useLocation} from 'react-router-dom';
import "../assets/css/hall1.css"
import SeanceService from '../redux/services/SeanceService';

function Hall1() {
    const [totalCost,setTotalCost] = React.useState<number>(0);
    const addCost=()=>{
        setTotalCost(totalCost+seance!.Cost)
    }
    const [key,setKey]= React.useState<boolean>(false)
    const {search} = useLocation();
    const [seance, setSeance] = React.useState<SeanceHall>();
    const searchParams = new URLSearchParams(search);
    const seanceId = searchParams.get("id");

    React.useEffect(() => {
        if (key) return;
        SeanceService.getSeanceById(seanceId!).then((res) => {
          if(res!== undefined){
            setSeance(res);
          }
        })
        setKey(true);
      }, [seance,key])

  return (
    <div style={{
        backgroundColor:"#635654",
        color: "white",
        height:"100%"
    }}>
        <div style={{
            backgroundColor:"#635654",
            color: "white",
        }}>
            <h2 className="py-4" style={{ 
                textAlign:"center"
            }}>
                {seance?.Film.Name}, {seance?.SeanceDate}, {seance?.SeanceTime}, {seance?.CinemaHall.HallName}, {seance?.Film.Restriction}+
            </h2>
        </div>
        <div style={{
            backgroundColor: "#635654",
            border:"3px solid #D0B3AA",
            borderRadius:"50px",
            width: "50%",
            alignItems:"center",
            margin:"0 auto"
        }}>
            <div className="mt-4" style={{
                backgroundColor:"gray",
                width:"78%",
                margin: "0 auto"
            }}>
                <h3 style={{
                    textAlign:"center"
                }}>Экран</h3>
            </div>
            <div className="my-4 mx-auto" style={{
            }}>
                {seance?.CinemaHall.Rows.map((row)=>(<div style={{
                    justifyContent:"space-between",
                    margin:"2rem 6rem",
                    alignItems:"center",
                }} id="r6" className="d-flex">
                    <p style={{
                        margin:"auto 0"
                    }}>Ряд {row.RowNumber}</p>
                        {row.Seats.map((seat)=>(
                            <>
                            {
                                (seat.SeatNumber===10)?
                                (
                                    <>
                                    {
                                        (seat.Status==="Забронировано")?
                                        (
                                            <Button variant="info" className="seatButton reserved button2digits">{seat.SeatNumber}</Button>
                                        ):(
                                            <>
                                            {
                                                (seat.Status==="Куплено")?
                                                (
                                                    <Button variant="danger" className="seatButton bought button2digits">{seat.SeatNumber}</Button>
                                                ):(
                                                    <Button variant="light" onClick={addCost} className="seatButton button2digits">{seat.SeatNumber}</Button>
                                                )
                                            }
                                            </>
                                        )
                                    }
                                    </>
                                ):(
                                    <>
                                    {
                                        (seat.Status==="Забронировано")?
                                        (
                                            <Button variant="info" className="seatButton reserved">{seat.SeatNumber}</Button>
                                        ):(
                                            <>
                                            {
                                                (seat.Status==="Куплено")?
                                                (
                                                    <Button variant="danger" className="seatButton bought">{seat.SeatNumber}</Button>
                                                ):(
                                                    <Button variant="light" onClick={addCost} className="seatButton">{seat.SeatNumber}</Button> 
                                                )
                                            }
                                            </>
                                        )
                                    } 
                                    </>   
                                )
                            }
                            </>
                        ))}


                     <p style={{
                        margin:"auto 0"
                    }}>Ряд {row.RowNumber}</p>
                    </div>))}
            </div>
            
            <div className="d-flex" style={{
                margin:"1rem 4rem",
                justifyContent:"space-between",
            }}>
                <div className="d-flex">
                    <div style={{
                        backgroundColor:"#F8F9FA",
                        width:"15px",
                        height:"15px",
                        marginTop:"0.25rem"
                    }}>
                    </div>
                    <h6 style={{ 
                        marginLeft:"1rem"
                    }}>
                        Свободно
                    </h6>
                </div>
                <div className="d-flex" style={{}}>
                    <div style={{
                       backgroundColor:"#787272",
                       width:"15px",
                       height:"15px",
                       marginTop:"0.25rem"
                    }}>
                    </div>
                    <h6 style={{ 
                        marginLeft:"1rem"
                    }}>
                    Выбрано
                    </h6>
                </div>
                <div className="d-flex">
                    <div style={{
                        backgroundColor:"#4794b5",
                        width:"15px",
                        height:"15px",
                        marginTop:"0.25rem"
                    }}>
                    </div>
                    <h6 style={{ 
                        marginLeft:"1rem"
                    }}>
                        Забронировано
                    </h6>
                </div>
                <div className="d-flex">
                    <div style={{
                        backgroundColor:"#c44747",
                        width:"15px",
                        height:"15px",
                        marginTop:"0.25rem"
                    }}>
                    </div>
                    <h6 style={{ 
                        marginLeft:"1rem"
                    }}>
                        Куплено
                    </h6>
                </div>
            </div>
            <p className="mt-4" style={{
                textAlign:"center",
                fontSize:"32px",
            }}>Сумма:{totalCost}</p>
            <div className='d-flex' style={{
                margin:"auto 0",
                justifyContent:"center",
            }}>
            <Button className="mx-4 mb-4" style={{
               backgroundColor:"#4794b5",
               borderColor:"#4794b5"
            }}>
                Забронировать
            </Button>
            <Button className="mx-4 mb-4" style={{
                backgroundColor:"#c44747",
                borderColor:"#c44747"
            }}>
                Купить
            </Button>
            </div>
            

        </div>
    </div>
  );
}

export default Hall1;