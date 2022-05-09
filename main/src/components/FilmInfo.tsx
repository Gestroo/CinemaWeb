import React from 'react';
import {Button, Card,Image} from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';
import joker from "../assets/img/joker.png";


function FilmInfo() {
  const navigate = useNavigate();
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
      }}>
        <Card.Body>
          <Image src={joker}  style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
        </Card.Body>
        </Card>
        <h2 className='my-2' style={{
            color:"#fff"
        }}>
            Описание
        </h2>
        <Button onClick={() => {navigate("/tickets")}} className="mx-4 mt-2" style={{
            backgroundColor: "#D0B3AA",
            borderColor: "#D0B3AA",
            height:"100%"}}>
          Купить билеты
        </Button>
      </div>
  );
}

export default FilmInfo;