import React from 'react';
import {Card,Image,Form,Button, Dropdown,Toast,ToastContainer} from 'react-bootstrap';
import {useNavigate, useLocation} from 'react-router-dom';
import {Booking} from '../models/BookingModel'
import { PostReview } from '../models/ReviewModel';
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

  const [values, setValues] = React.useState<PostReview>({
    Film: {
      ID:0,
      Name: "",
      Duration: 0,
      Genre: {ID:0,
        Title:""},
      Restriction: 0,
      Description:"",  
      Poster: ""
    },
    Client:{
      id:0,
      birthdate:'',
      lastname: '',
      firstname: '',
      middlename: '',
      phone: '',
      email: '',
    },
    Rating:0,
    Comment:""
})
const addReview=()=>{
  const data: PostReview = {
          Film:booking!.Ticket.Seance.Film,
          Client:booking!.Client,
          Rating:rating!,
          Comment:comment!,
  };
     ReviewService.AddReview(data);
    
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
          <Image src={booking?.Ticket.Seance.Film.Poster}  style={{
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
           {booking?.Ticket.Seance.Film.Name}
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
    <Toast show={show} bg="danger" autohide delay={3000} onClose={toggleShow}>
    <Toast.Header>
        <strong>Ошибка</strong>
    </Toast.Header>
    <Toast.Body>Неверный телефон или пароль</Toast.Body>
  </Toast>
    </ToastContainer>
        
        
      </div>
  );
}

export default NewReview;