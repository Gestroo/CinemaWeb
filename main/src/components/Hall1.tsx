import React from 'react';
import {Button, Modal, Toast, ToastContainer} from 'react-bootstrap';
import {SeanceHall} from '../models/SeanceModel'
import {useNavigate} from 'react-router-dom';
import {useLocation} from 'react-router-dom';
import "../assets/css/hall1.css"
import SeanceService from '../redux/services/SeanceService';
import {useSelector} from "react-redux";
import {RootState} from "../redux/store";
import {Seat} from '../models/SeatModel';
import AuthModal from './AuthModal';
import {Tickets} from '../models/TicketModel';
import TicketService from '../redux/services/TicketService';
import 'intro.js/introjs.css';
import {Steps, Hints} from 'intro.js-react';
import TrainingService from "../redux/services/TrainingService.ts";


function Hall1() {
    const navigate = useNavigate();
    const [toastBuyShow, setToastBuyShow] = React.useState<boolean>(false);
    const toggleBuyShow = () => setToastBuyShow(!toastBuyShow);
    const [toastBookShow, setToastBookShow] = React.useState<boolean>(false);
    const toggleBookShow = () => setToastBookShow(!toastBookShow);
    const [seance, setSeance] = React.useState<SeanceHall>();
    const [pickedSeats, setPickedSeats] = React.useState<Seat[]>([])
    const [stepsEnabled,setStepsEnabled] = React.useState(false);
    const [values, setValues] = React.useState<Tickets>({
        id: 0,
        seance: 0,
        seat: pickedSeats,
        dateTime: ""
    })

    const steps = TrainingService.steps;
    // [
    //     {
    //         element: '#hall',
    //         intro: 'Выберите место в соответствии с легендой',
    //         position: 'right',
    //     },
    //     {
    //         element: '#buy',
    //         intro: 'Нажмите на кнопку "Купить" ',
    //         position: 'right',
    //     },
    //     {
    //         element: '#confirm',
    //         intro: 'Нажмите на кнопку "Оплатить" ',
    //         position: 'right',
    //     }
    // ];

    const [show, setShow] = React.useState(false);
    const [buyShow, setBuyShow] = React.useState(false);
    const user = useSelector((state: RootState) => state);
    const buyHandleClose = () => setBuyShow(false);
    const buyHandleShow = () => setBuyShow(true);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [open, setOpen] = React.useState(false);

    const pickSeat = (seat: Seat) => {
        if (pickedSeats.includes(seat)) {
            setPickedSeats((pickedSeats) => [...pickedSeats.filter(i => i !== seat)]);
            const button = document.getElementById(seat.id.toString());
            button!.style.backgroundColor = "#F8F9FA";
            button!.style.borderColor = "#F8F9FA";
        } else {
            setPickedSeats(pickedSeats => [...pickedSeats, seat]);
            const button = document.getElementById(seat.id.toString());
            button!.style.backgroundColor = "#787272";
            button!.style.borderColor = "#787272";
        }
    }
    const [cost, setCost] = React.useState<number>(0);
    const [key, setKey] = React.useState<boolean>(false);
    const {search} = useLocation();

    const searchParams = new URLSearchParams(search);
    const seanceId = searchParams.get("id");

    React.useEffect(() => {
        if (key) return;
        SeanceService.getSeanceById(seanceId!).then((res) => {
            if (res !== undefined) {
                setSeance(res);
                setCost(res.cost);
            }
        })
        setKey(true);
    }, [seance, key])

    return (
        <>
            <Steps
                enabled={stepsEnabled||true}
                steps={steps}
                initialStep={2}
                // onBeforeExit={()=>{return confirm("Вы уверены что хотите пропустить обучение?");}}
                onExit={()=>{setStepsEnabled(false)}}
                options={{
                    skipLabel: '<h6 style=\'margin: 5px 0 0 -70px; padding: 0; color: #0D47A1\'>Пропустить</h6>',
                    exitOnOverlayClick:false,
                    showBullets:false,
                    hideNext: true,
                }}
            />
            <div style={{
                backgroundColor: "#635654",
                color: "white",
                height: "100%"
            }}>
                <div style={{
                    backgroundColor: "#635654",
                    color: "white",
                }}>
                    <h2 className="py-4" style={{
                        textAlign: "center"
                    }}>
                        {seance?.film.name}, {seance?.seanceDate}, {seance?.seanceTime}, {seance?.cinemaHall.hallName}, {seance?.film.restriction}+
                    </h2>
                </div>
                <div style={{
                    backgroundColor: "#635654",
                    border: "3px solid #D0B3AA",
                    borderRadius: "50px",
                    width: "50%",
                    alignItems: "center",
                    margin: "0 auto"
                }}>
                    <div className="mt-4" style={{
                        backgroundColor: "gray",
                        width: "78%",
                        margin: "0 auto"
                    }}>
                        <h3 style={{
                            textAlign: "center"
                        }}>Экран</h3>
                    </div>
                    <div id={"hall"}>
                        <div  className="my-4 mx-auto" style={{}}>
                            {seance?.cinemaHall.rows.map((row) => (<div style={{
                                justifyContent: "space-between",
                                margin: "2rem 6rem",
                                alignItems: "center",
                            }} id="r6" className="d-flex">
                                <p style={{
                                    margin: "auto 0"
                                }}>Ряд {row.rowNumber}</p>
                                {row.seats.map((seat) => (
                                    <>
                                        {
                                            (seat.seatNumber === 10) ?
                                                (
                                                    <>
                                                        {
                                                            (seat.status == "Забронировано") ?
                                                                (
                                                                    <Button id={seat!.id.toString()} variant="info"
                                                                            className="seatButton reserved button2digits">{seat.seatNumber}</Button>
                                                                ) : (
                                                                    <>
                                                                        {
                                                                            (seat.status === "Куплено") ?
                                                                                (
                                                                                    <Button id={seat!.id.toString()}
                                                                                            variant="danger"
                                                                                            className="seatButton bought button2digits">{seat.seatNumber}</Button>
                                                                                ) : (
                                                                                    <Button id={seat!.id.toString()} variant="light"
                                                                                            onClick={e => {
                                                                                                pickSeat(seat)
                                                                                            }}
                                                                                            className="seatButton button2digits">{seat.seatNumber}</Button>
                                                                                )
                                                                        }
                                                                    </>
                                                                )
                                                        }
                                                    </>
                                                ) : (
                                                    <>
                                                        {
                                                            (seat.status == "Забронировано") ?
                                                                (
                                                                    <Button id={seat!.id.toString()} variant="info"
                                                                            className="seatButton reserved">{seat.seatNumber}</Button>
                                                                ) : (
                                                                    <>
                                                                        {
                                                                            (seat.status === "Куплено") ?
                                                                                (
                                                                                    <Button id={seat!.id.toString()}
                                                                                            variant="danger"
                                                                                            className="seatButton bought">{seat.seatNumber}</Button>
                                                                                ) : (
                                                                                    <Button id={seat!.id.toString()} variant="light"
                                                                                            onClick={e => {
                                                                                                pickSeat(seat)
                                                                                            }}
                                                                                            className="seatButton">{seat.seatNumber}</Button>
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
                                    margin: "auto 0"
                                }}>Ряд {row.rowNumber}</p>
                            </div>))}
                        </div>

                        <div id={"legend"} className="d-flex" style={{
                            margin: "1rem 4rem",
                            justifyContent: "space-between",
                        }}>
                            <div className="d-flex">
                                <div style={{
                                    backgroundColor: "#F8F9FA",
                                    width: "15px",
                                    height: "15px",
                                    marginTop: "0.25rem"
                                }}>
                                </div>
                                <h6 style={{
                                    marginLeft: "1rem"
                                }}>
                                    Свободно
                                </h6>
                            </div>
                            <div className="d-flex" style={{}}>
                                <div style={{
                                    backgroundColor: "#787272",
                                    width: "15px",
                                    height: "15px",
                                    marginTop: "0.25rem"
                                }}>
                                </div>
                                <h6 style={{
                                    marginLeft: "1rem"
                                }}>
                                    Выбрано
                                </h6>
                            </div>
                            <div className="d-flex">
                                <div style={{
                                    backgroundColor: "#4794b5",
                                    width: "15px",
                                    height: "15px",
                                    marginTop: "0.25rem"
                                }}>
                                </div>
                                <h6 style={{
                                    marginLeft: "1rem"
                                }}>
                                    Забронировано
                                </h6>
                            </div>
                            <div className="d-flex">
                                <div style={{
                                    backgroundColor: "#c44747",
                                    width: "15px",
                                    height: "15px",
                                    marginTop: "0.25rem"
                                }}>
                                </div>
                                <h6 style={{
                                    marginLeft: "1rem"
                                }}>
                                    Куплено
                                </h6>
                            </div>
                        </div>
                    </div>

                    <p className="mt-4" style={{
                        textAlign: "center",
                        fontSize: "32px",
                    }}>Сумма:{pickedSeats.length * cost}</p>
                    <div className='d-flex' style={{
                        margin: "auto 0",
                        justifyContent: "center",
                    }}>
                        <Button onClick={() => {
                            if (user.client.isAuth) {
                                setValues({
                                    id: 0,
                                    seance: seance!.id,
                                    seat: pickedSeats,
                                    dateTime: ""
                                })
                                handleShow();
                            } else {
                                setOpen(true)
                            }
                        }} className="mx-4 mb-4" style={{
                            backgroundColor: "#4794b5",
                            borderColor: "#4794b5"
                        }}>
                            Забронировать
                        </Button>
                        <Button id={"buy"} onClick={e => {
                            if (user?.client.isAuth) {
                                setValues({
                                    id: 0,
                                    seance: seance!.id,
                                    seat: pickedSeats,
                                    dateTime: ""
                                })
                                buyHandleShow();
                            } else {
                                setOpen(true)
                            }
                        }} className="mx-4 mb-4" style={{
                            backgroundColor: "#c44747",
                            borderColor: "#c44747"
                        }}>
                            Купить
                        </Button>
                    </div>
                </div>
                <Modal show={show}
                       onHide={handleClose} backdrop="static">
                    <Modal.Header>
                        <Modal.Title>
                            Подтверждение
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        Количество мест : {pickedSeats.length}<br/>
                        К оплате : {pickedSeats.length * cost}
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Отмена
                        </Button>
                        <Button onClick={e => {
                            TicketService.BookTicket(values).then((res: any) => {
                                if (res) {
                                    handleClose();
                                    toggleBookShow();
                                    ;setTimeout(() => {
                                        navigate(0)
                                    }, 3000)
                                }
                            })
                        }}>
                            Подтвердить
                        </Button>
                    </Modal.Footer>
                </Modal>
                <Modal show={buyShow}
                       onHide={buyHandleClose} backdrop="static">
                    <Modal.Header style={{backgroundColor: "#D0B3AA",}}>
                        <Modal.Title>
                            Подтверждение
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body style={{
                        backgroundColor: "#635654",
                        color: "#fff",
                    }}>
                        Количество мест : {pickedSeats.length}<br/>
                        К оплате : {pickedSeats.length * cost}
                    </Modal.Body>
                    <Modal.Footer style={{
                        backgroundColor: "#635654",
                        color: "#fff",
                    }}>
                        <Button variant="secondary" onClick={buyHandleClose}>
                            Отмена
                        </Button>
                        <Button id={"confirm"} onClick={e => {
                            TicketService.BuyTicket(values).then((res: any) => {
                                if (res) {
                                    buyHandleClose();
                                    toggleBuyShow();
                                    setTimeout(() => {
                                        navigate(0)
                                    }, 3000)
                                }
                            })
                        }}>
                            Оплатить
                        </Button>
                    </Modal.Footer>
                </Modal>
                <AuthModal open={open} handlerClose={() => setOpen(false)}/>
                <ToastContainer position="top-end">
                    <Toast show={toastBookShow} bg="success" autohide delay={3000} onClose={toggleBookShow}>
                        <Toast.Header>
                            <strong>Успешно</strong>
                        </Toast.Header>
                        <Toast.Body>Места забронированы</Toast.Body>
                    </Toast>
                </ToastContainer>
                <ToastContainer position="top-end">
                    <Toast show={toastBuyShow} bg="success" autohide delay={3000} onClose={toggleBuyShow}>
                        <Toast.Header>
                            <strong>Успешно</strong>
                        </Toast.Header>
                        <Toast.Body>Билет отправлен на вашу почту</Toast.Body>
                    </Toast>
                </ToastContainer>
            </div>
        </>
    );
}

export default Hall1;