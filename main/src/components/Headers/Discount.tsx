import React from 'react';
import {Card,Image,Button} from 'react-bootstrap';
import Discounts from "../../assets/img/discount.jpg"

function Discount() {
  return (
    <div>
       <h2 className='mt-4' style={{
        color:"#fff",
        textAlign:"center",
       }}>  Акции</h2>
<div>
        <div className="d-flex mb-4 justify-between" style={{
          justifyContent:"space-between",
          marginLeft:"8rem",
          marginRight:"8rem",
          marginTop:"4rem",
        }}>
        <Card style={{
          width:"20%"
        }}>
          <Image src={Discounts}/>
          <Card.Body>
          <Card.Title>Студенческая</Card.Title>
          <Card.Text>
            По вторникам студентам предоставляется скидка в 50%
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        <Card style={{
          width:"20%"
        }}>
          <Image src={Discounts}/>
          <Card.Body>
          <Card.Title>Для больших компаний </Card.Title>
          <Card.Text>
            От 6 билетов в чеке скидка на билеты 15%
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        <Card style={{
          width:"20%"
        }}>
          <Image src={Discounts}/>
          <Card.Body>
          <Card.Title>Ночь кино </Card.Title>
          <Card.Text>
            Получите проход на три ночных фильма по цене двух
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        </div>
       </div>



    </div>
    
  );
}

export default Discount;
