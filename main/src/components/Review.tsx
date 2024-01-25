import React from 'react';
import {Card,Image,Form,Button, Dropdown,Toast,ToastContainer} from 'react-bootstrap';
import {useNavigate, useLocation} from 'react-router-dom';
import {Booking} from '../models/BookingModel'
import {Review} from '../models/ReviewModel';
import BookingService from '../redux/services/BookingService';
import "../assets/css/index.css"
import ReviewService from '../redux/services/ReviewService';

function NewReview() {
  const [show, setShow] = React.useState<boolean>(false);
  const toggleShow = () => setShow(!show);
  const [booking, setBooking] = React.useState<Booking>();
  const [rating,setRating] = React.useState<number>(0);
  const [comment,setComment] = React.useState<string>("")
  const {search} = useLocation();
  const searchParams = new URLSearchParams(search);
  const bookingId = searchParams.get("id");
  const [key,setKey] = React.useState<boolean>(false)
const addReview=()=>{
  const data: Review = {
          id: 0,
          film:booking!.ticket.seance.film,
          client:booking!.client,
          rating:rating!,
          comment:comment!,
  };
     ReviewService.AddReview(data).then((res)=>{
      if (res){setShow(true);}
     });
    
  }
  React.useEffect(() => {
    if (key) return;
    BookingService.getBookingById(bookingId!).then((res) => {
      if(res!== undefined){
        setBooking(res);
      }
    })
    setKey(true);
  }, [booking,key])
  return (
      <div className='d-flex'
      style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
        width:"100%"}}>
        <Card className=""
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
        width:"320px"
      }}>
        <Card.Body>
          <Image src={booking?.ticket.seance.film.poster} style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
        </Card.Body>
        </Card>
        <div style={{
          width:"90%"
        }}>
        <div className='mx-4'>
        <h2 className='my-2' style={{
            color:"#fff"
        }}>
           {booking?.ticket.seance.film.name}
        </h2>
            <Form className="mt-4">
              <Form.Select value={rating} 
                      onChange={e => {
                          setRating(Number(e.target.value));
                      }} style={{
                width:"120px"
              }}>
                <option value="0">Оценка</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Select>
                <Form.Group className="mt-2">
                    <Form.Label>Комментарий</Form.Label>
                    <Form.Control value={comment} 
                      onChange={e => {
                          setComment(e.target.value);
                      }} as="textarea" maxLength={300} style={{
                      maxHeight:"160px",
                      width:"500px"
                    }}></Form.Control>
                </Form.Group>
            </Form>
            <Button onClick={addReview} className="mt-4" style={{
              backgroundColor:"#D0B3AA",
              borderColor:",#D0B3AA",
              color:"#000",
              fontWeight:"bold",
            }}>
              Сохранить
            </Button>




          </div>
        <div>
        
        </div>
        </div>
        <ToastContainer position="top-end">
    <Toast show={show} bg="success" autohide delay={3000} onClose={toggleShow}>
    <Toast.Header>
        <strong>Успешно</strong>
    </Toast.Header>
    <Toast.Body>Отзыв успешно добавлен</Toast.Body>
  </Toast>
    </ToastContainer>
        
        
      </div>
  );
}

export default NewReview;