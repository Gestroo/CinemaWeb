import React from 'react';
import {Button, Modal,Toast,ToastContainer} from 'react-bootstrap';
import {Seance} from '../models/SeanceModel'
import {SeanceHall} from '../models/SeanceModel'
import {useNavigate} from 'react-router-dom';
import {useLocation} from 'react-router-dom';
import "../assets/css/hall1.css"
import SeanceService from '../redux/services/SeanceService';
import { useSelector} from "react-redux";
import { RootState} from "../redux/store";
import { Seat } from '../models/SeatModel';
import AuthModal from './AuthModal';
import { Tickets } from '../models/TicketModel';
import TicketService from '../redux/services/TicketService';


function Hall1() {
    const navigate = useNavigate();
    const [toastBuyShow, setToastBuyShow] = React.useState<boolean>(false);
    const toggleBuyShow = () => setToastBuyShow(!toastBuyShow);
    const [toastBookShow, setToastBookShow] = React.useState<boolean>(false);
    const toggleBookShow = () => setToastBookShow(!toastBookShow);
    const [seance, setSeance] = React.useState<SeanceHall>();
    const [pickedSeats,setPickedSeats]=React.useState<Seat[]>([])
    const [values, setValues] = React.useState<Tickets>({
        ID:0,
        Seance: 0,
        Seat: pickedSeats,
        DateTime:""
    })


    
    const [show, setShow] = React.useState(false);
    const [buyShow, setBuyShow] = React.useState(false);
    const user = useSelector((state: RootState) => state);
    const buyHandleClose = () => setBuyShow(false);
    const buyHandleShow = () => setBuyShow(true);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [open, setOpen] = React.useState(false);
    
     const pickSeat=(seat:Seat)=>{
    if (pickedSeats.includes(seat)){
        setPickedSeats((pickedSeats)=>[...pickedSeats.filter(i=>i !== seat)]);
        const button = document.getElementById(seat.ID.toString());
        button!.style.backgroundColor="#F8F9FA";
        button!.style.borderColor="#F8F9FA";
    }
    else {
        setPickedSeats(pickedSeats=>[...pickedSeats,seat]);
        const button = document.getElementById(seat.ID.toString());
        button!.style.backgroundColor="#787272";
        button!.style.borderColor="#787272";
    }
    }
    const [cost,setCost] = React.useState<number>(0);
    const [key,setKey]= React.useState<boolean>(false);
    const {search} = useLocation();
   
    const searchParams = new URLSearchParams(search);
    const seanceId = searchParams.get("id");

    React.useEffect(() => {
        if (key) return;
        SeanceService.getSeanceById(seanceId!).then((res) => {
          if(res!== undefined){
            setSeance(res);
            setCost(res.Cost);
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
                }}>??????????</h3>
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
                    }}>?????? {row.RowNumber}</p>
                        {row.Seats.map((seat)=>(
                            <>
                            {
                                (seat.SeatNumber===10)?
                                (
                                    <>
                                    {
                                        (seat.Status==="??????????????????????????")?
                                        (
                                            <Button id={seat!.ID.toString()} variant="info" className="seatButton reserved button2digits">{seat.SeatNumber}</Button>
                                        ):(
                                            <>
                                            {
                                                (seat.Status==="??????????????")?
                                                (
                                                    <Button id={seat!.ID.toString()} variant="danger" className="seatButton bought button2digits">{seat.SeatNumber}</Button>
                                                ):(
                                                    <Button id={seat!.ID.toString()} variant="light" onClick={e=>{pickSeat(seat)}} className="seatButton button2digits">{seat.SeatNumber}</Button>
                                                )
                                            }
                                            </>
                                        )
                                    }
                                    </>
                                ):(
                                    <>
                                    {
                                        (seat.Status==="??????????????????????????")?
                                        (
                                            <Button id={seat!.ID.toString()} variant="info" className="seatButton reserved">{seat.SeatNumber}</Button>
                                        ):(
                                            <>
                                            {
                                                (seat.Status==="??????????????")?
                                                (
                                                    <Button id={seat!.ID.toString()} variant="danger" className="seatButton bought">{seat.SeatNumber}</Button>
                                                ):(
                                                    <Button id={seat!.ID.toString()} variant="light" onClick={e=>{pickSeat(seat)}} className="seatButton">{seat.SeatNumber}</Button> 
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
                    }}>?????? {row.RowNumber}</p>
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
                        ????????????????
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
                    ??????????????
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
                        ??????????????????????????
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
                        ??????????????
                    </h6>
                </div>
            </div>
            <p className="mt-4" style={{
                textAlign:"center",
                fontSize:"32px",
            }}>??????????:{pickedSeats.length*cost}</p>
            <div className='d-flex' style={{
                margin:"auto 0",
                justifyContent:"center",
            }}>
            <Button onClick={()=>{
                if (user.client.isAuth){
                    setValues({ID:0,
                        Seance: seance!.ID,
                        Seat: pickedSeats,
                        DateTime:""})
                handleShow();
            }
            else{setOpen(true)}
        }} className="mx-4 mb-4" style={{
               backgroundColor:"#4794b5",
               borderColor:"#4794b5"
            }}>
                ??????????????????????????
            </Button>
            <Button onClick={e=>{if (user?.client.isAuth){
                setValues({ID:0,
                    Seance: seance!.ID,
                    Seat: pickedSeats,
                    DateTime:""})
                buyHandleShow();
            }
            else{setOpen(true)}
        }} className="mx-4 mb-4" style={{
                backgroundColor:"#c44747",
                borderColor:"#c44747"
            }}>
                ????????????
            </Button>
            </div>
        </div>
        <Modal show={show}
        onHide={handleClose} backdrop="static">
            <Modal.Header>
                <Modal.Title>
                    ??????????????????????????
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                ???????????????????? ???????? : {pickedSeats.length}<br/>
                ?? ???????????? : {pickedSeats.length*cost}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    ????????????
                </Button>
                <Button onClick={e=>{ TicketService.BookTicket(values).then((res:any)=>{if(res){handleClose();toggleBookShow();;setTimeout(()=>{navigate(0)},3000)}})} }>
                    ??????????????????????
                </Button>
            </Modal.Footer>
        </Modal>
        <Modal show={buyShow}
        onHide={buyHandleClose} backdrop="static">
            <Modal.Header>
                <Modal.Title>
                    ??????????????????????????
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                ???????????????????? ???????? : {pickedSeats.length}<br/>
                ?? ???????????? : {pickedSeats.length*cost}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={buyHandleClose}>
                    ????????????
                </Button>
                <Button onClick={e=>{TicketService.BuyTicket(values).then((res:any)=>{if(res){buyHandleClose();toggleBuyShow();setTimeout(()=>{navigate(0)},3000)}})}}>
                    ????????????????
                </Button>
            </Modal.Footer>
        </Modal>
        <AuthModal open={open} handlerClose={() => setOpen(false)}/>
        <ToastContainer position="top-end">
    <Toast show={toastBookShow} bg="success" autohide delay={3000} onClose={toggleBookShow}>
    <Toast.Header>
        <strong>??????????????</strong>
    </Toast.Header>
    <Toast.Body>?????????? ??????????????????????????</Toast.Body>
  </Toast>
    </ToastContainer>
        <ToastContainer position="top-end">
    <Toast show={toastBuyShow} bg="success" autohide delay={3000} onClose={toggleBuyShow}>
    <Toast.Header>
        <strong>??????????????</strong>
    </Toast.Header>
    <Toast.Body>?????????? ?????????????????? ???? ???????? ??????????</Toast.Body>
  </Toast>
    </ToastContainer>
    </div>
  );
}

export default Hall1;