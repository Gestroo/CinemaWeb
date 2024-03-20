import React from 'react';
import {Dropdown,Container,Button} from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';
import { Review } from '../models/ReviewModel';
import ReviewService from '../redux/services/ReviewService';


function MyReviews() {
    const navigate = useNavigate();
const[key,setKey] = React.useState<boolean>(false)
const[reviews,setReviews]=React.useState<Review[]>([])
const [option,setOption] = React.useState<number>(0);
    const optionToString = (option:number) =>{
        switch (option){
            case 0: return "Сортировать"
            case 1: return "По дате"
            case 2: return "По алфавиту"
            case 3: return "По оценке"
        }

    }
const filterReviews = (option:number)=>{
  ReviewService.filterReviews(option).then((res) => {
    console.log(res);
    setReviews(res);
  })
}

React.useEffect(() => {
    if (key) return;
    ReviewService.getReviewsByClientId().then((res:any)=>{setReviews(res)})
    setKey(true)
  }, [reviews,key])

  return (
    <div className="d-flex flex-column align-items-center" style={{
        backgroundColor: "#635654",
        color:"white",
        height:"100%",
    }}>
            <div className='align-items-center'  style={{
                height:"100%",
            }}>
                <h2 className='mt-4 text-center'>Мои отзывы</h2>
            <Dropdown style={{
                border:"1px solid #D0B3AA",
                borderRadius:"15px"
            }}>
                <Dropdown.Toggle style={{
                            backgroundColor: "#635654",
                            margin:"auto 3rem",
                            borderColor:"#635654",
                            fontSize:"20px"
                }}>{optionToString(option)}</Dropdown.Toggle>
                <Dropdown.Menu>
                <Dropdown.Item onClick={e=>{setOption(1);filterReviews(1)}} value={1}>По дате</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setOption(2);filterReviews(2)}} value={2}>По алфавиту</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setOption(3);filterReviews(3)}} value={3}>По оценке</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>
            </div>
            <Container className='mt-4 row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3 col-lg-11 col-md-8 mx-auto'>
        {reviews.map((review)=>(
            <div className='col'>
            <div className="mx-4 "
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
        border:"2px solid #D0B3AA",
        borderRadius:"15px",
      }}>    
          <h3 style={{
            textAlign:"center",
          }}>{review.film.name}</h3>
          <h4 style={{
            textAlign:"center",
          }}>
            Оценка: {review.rating}
          </h4>
          <h5 style={{
            textAlign:"center",}}>
                {review.comment}
          </h5> 
      </div>
          </div>
        ))}
      </Container>
        </div>
  );
}

export default MyReviews;