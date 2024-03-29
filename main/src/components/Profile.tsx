import React from 'react';
import {Dropdown, Container, Button, Modal} from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';
import {Booking} from '../models/BookingModel';
import BookingService from '../redux/services/BookingService';

function Profile() {
    const [show, setShow] = React.useState(false);
    const [option, setOption] = React.useState<number>(0);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const navigate = useNavigate();
    const [key, setKey] = React.useState<boolean>(false);
    const [bookings, setBookings] = React.useState<Booking[]>([]);
    const [modalBooking, setModalBooking] = React.useState<Booking>();
    const filterBookings = (option: number) => {
        BookingService.filterBookings(option).then((res) => {
            console.log(res);
            setBookings(res);
        })
    }
    const optionToString = (option:number) =>{
        switch (option){
            case 0: return "Сортировать"
            case 1: return "По дате покупки"
            case 2: return "По алфавиту"
            case 3: return "По длительности"
        }

    }

    React.useEffect(() => {
        if (key) return;
        BookingService.getBookingsByClientId().then((res: any) => {
            setBookings(res)
        })
        setKey(true)
    }, [bookings, key])

    return (
        <div className="d-flex flex-column align-items-center" style={{
            backgroundColor: "#635654",
            color: "white",
            height: "100%",
        }}>
            <div className='' style={{
                height: "100%",
            }}>
                <h2 className='mt-4 mx-auto'>История заказов</h2>
                <Dropdown style={{
                    border: "1px solid #D0B3AA",
                    borderRadius: "15px"
                }}>
                    <Dropdown.Toggle style={{
                        backgroundColor: "#635654",
                        margin: "auto 3rem",
                        borderColor: "#635654",
                        fontSize: "20px"
                    }}>{optionToString(option)}</Dropdown.Toggle>
                    <Dropdown.Menu>
                        <Dropdown.Item onClick={e => {
                            setOption(1);
                            filterBookings(1)
                        }}>По дате покупки</Dropdown.Item>
                        <Dropdown.Item onClick={e => {
                            setOption(2);
                            filterBookings(2)
                        }}>По алфавиту</Dropdown.Item>
                        <Dropdown.Item onClick={e => {
                            setOption(3);
                            filterBookings(3)
                        }}>По длительности</Dropdown.Item>
                    </Dropdown.Menu>
                </Dropdown>
            </div>
            <Container className='mt-4 row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3 col-lg-11 col-md-8 mx-auto'>
                {bookings.map((booking) => (
                    <>
                        <div className='col'>
                            <div className="mx-4 "
                                 style={{
                                     backgroundColor: "#635654",
                                     borderColor: "#635654",
                                     color: "#fff",
                                     border: "2px solid #D0B3AA",
                                     borderRadius: "15px",
                                 }}>
                                <h3 style={{
                                    textAlign: "center",
                                }}>{booking.ticket.seance.film.name}</h3>
                                <h4 style={{
                                    textAlign: "center",
                                }}>
                                    {booking.ticket.seance.seanceDate} {booking.ticket.seance.seanceTime}
                                </h4>
                                <div className="my-2 mx-4 d-flex" style={{
                                    justifyContent: 'space-between'
                                }}>
                                    <Button onClick={() => {
                                        setModalBooking(booking);
                                        console.log(booking);
                                        handleShow();
                                    }} style={{
                                        backgroundColor: "#D0B3AA",
                                        borderColor: "#D0B3AA",
                                        color: "#000",
                                        fontWeight: "bold",
                                    }}> Подробнее</Button>
                                    <Button onClick={() => {
                                        navigate("/review?id=" + booking.id)
                                    }} style={{
                                        backgroundColor: "#D0B3AA",
                                        borderColor: "#D0B3AA",
                                        color: "#000",
                                        fontWeight: "bold",

                                    }}>
                                        Написать отзыв
                                    </Button>
                                </div>
                            </div>
                        </div>

                    </>
                ))}
            </Container>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton style={{
                    backgroundColor: "#D0B3AA",
                }}>
                    <Modal.Title>Информация</Modal.Title>
                </Modal.Header>
                <Modal.Body style={{
                    backgroundColor: "#635654",
                    color: "#fff",
                }}>
                    <h2>
                        Название фильма: {modalBooking?.ticket.seance.film.name}
                    </h2>
                    <h3>Жанр: {modalBooking?.ticket.seance.film.genre.title}</h3>
                    <h3>Дата: {modalBooking?.ticket.seance.seanceDate} {modalBooking?.ticket.seance.seanceTime}</h3>
                    <h4>{modalBooking?.ticket.seance.cinemaHall.hallName}</h4>
                    <h4>Ряд: {modalBooking?.ticket.row?.rowNumber}</h4>
                    <h4>Место: {modalBooking?.ticket.seat.seatNumber}</h4>
                </Modal.Body>
            </Modal>
        </div>
    );
}

export default Profile;
