import React from 'react';
import {Dropdown,Container,Button} from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';
import { Review } from '../models/ReviewModel';
import ReviewService from '../redux/services/ReviewService';

function MyReviews() {
    const navigate = useNavigate();
const[key,setKey] = React.useState<boolean>(false)
const[reviews,setReviews]=React.useState<Review[]>([])

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
            <div className=''  style={{
                height:"100%",
            }}>
                <h2 className='mt-4 mx-auto'>Мои отзывы</h2>
            <Dropdown style={{
                border:"1px solid #D0B3AA",
                borderRadius:"15px"
            }}>
                <Dropdown.Toggle style={{
                            backgroundColor: "#635654",
                            margin:"auto 3rem",
                            borderColor:"#635654",
                            fontSize:"20px"
                }}>Сортировать</Dropdown.Toggle>
                <Dropdown.Menu>
                <Dropdown.Item>По дате</Dropdown.Item>
                    <Dropdown.Item>По алфавиту</Dropdown.Item>
                    <Dropdown.Item>По длительности</Dropdown.Item>
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
          }}>{review.Film.Name}</h3>
          <h4 style={{
            textAlign:"center",
          }}>
            Оценка: {review.Rating}
          </h4>
          <h5 style={{
            textAlign:"center",}}>
                {review.Comment}
          </h5> 
      </div>
          </div>
        ))}
      </Container>
        </div>
  );
}

export default MyReviews;