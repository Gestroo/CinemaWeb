import { CanceledError } from 'axios';
import React from 'react';
import {Card,Button,Image} from 'react-bootstrap';
import newsPic from "../../assets/img/news.jpg"

function News() {
  return (
    <div>
       <h2 className='mt-4' style={{ 
        backgroundColor:"#635654",
        color:"#fff",
        textAlign:"center", }}>
Новости
       </h2>
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
          <Image src={newsPic}/>
          <Card.Body>
          <Card.Title>Новый фильм </Card.Title>
          <Card.Text>
            Компания Barner Wrothers заявила о начале съемок нового фильма "Форсаж 13"
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        <Card style={{
          width:"20%"
        }}>
          <Image src={newsPic}/>
          <Card.Body>
          <Card.Title>Новый фильм </Card.Title>
          <Card.Text>
            Компания Sidney начала съемку новой части "Пиратов карибского моря" c Джонни Деппом в главной роли
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        <Card style={{
          width:"20%"
        }}>
          <Image src={newsPic}/>
          <Card.Body>
          <Card.Title>Рейтинги </Card.Title>
          <Card.Text>
            Журнал The Movie составил список самых кассовых фильмов за 2021 год
          </Card.Text>
          <Button>Подробнее</Button>
          </Card.Body>
  
        </Card>
        </div>
       </div>
  
          

    </div>
  );
}

export default News;
