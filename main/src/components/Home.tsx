import React from 'react';
import {Card, Carousel} from 'react-bootstrap';
import Image from 'react-bootstrap/Image'
import "bootstrap/dist/css/bootstrap.min.css";
import violet1 from "../assets/img/Violet2.jpg";
import violet2 from "../assets/img/Violet3.jpg";
import violet3 from "../assets/img/violet6.jpg";
import matrix from "../assets/img/matrix.png";
import harry from "../assets/img/harry.png";
import joker from "../assets/img/joker.png";
import lotr from "../assets/img/lotr.png";
import {useNavigate} from 'react-router-dom';
import "../assets/css/index.css";

function Home() {
  const navigate = useNavigate();
  return (
    <div style={{
      backgroundColor: "#635654",
    }}>
      <div  className="d-flex">
        <Carousel className="mx-auto my-4" fade style={{
          width:"640px",
        }}>
          <Carousel.Item>
              <Image src={violet1} style={{
                width:"640px",
                height:"360px",
              }}></Image>
            </Carousel.Item>
            <Carousel.Item>
              <Image src={violet2} style={{
                width:"640px",
                height:"360px",
              }}></Image>
            </Carousel.Item>
            <Carousel.Item>
              <Image src={violet3} style={{
                width:"640px",
                height:"360px",
              }}></Image>
            </Carousel.Item>
        </Carousel>
        <div>

        </div>
      </div>
       <div className="d-flex" style={{ 
      justifyContent:"space-between",
      
    }}>
       <Card onClick={()=> {navigate("/film")}} className="mx-4 film"
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
          <h3 style={{
            textAlign:"center",
          }}>Джокер</h3>
        </Card.Body>
      </Card>
      <Card className="mx-4"
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff"
      }}>
        <Card.Body>
          <Image src={lotr}  style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
          <h3 style={{
            textAlign:"center",
          }}>Властелин колец</h3>
        </Card.Body>
      </Card>
      <Card className="mx-4" 
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff"
      }}>
        <Card.Body>
          <Image src={harry}  style={{
            width:"270px",
            height:"360px"
          }}> 
          </Image>
          <h3 style={{
            textAlign:"center",
          }}>Гарри Поттер</h3>
        </Card.Body>
      </Card>
      <Card className="mx-4"
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff"
      }}>
        <Card.Body>
          <Image src={matrix}  style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
          <h3 style={{
            textAlign:"center",
          }}>Матрица</h3>
        </Card.Body>
      </Card>
      </div>
    </div>
   
  );
}

export default Home;
