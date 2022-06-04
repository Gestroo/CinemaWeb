import React from 'react';
import {Card, Container, Carousel,Form,Dropdown,FloatingLabel} from 'react-bootstrap';
import Image from 'react-bootstrap/Image'
import "bootstrap/dist/css/bootstrap.min.css";
import violet1 from "../../assets/img/Violet2.jpg";
import violet2 from "../../assets/img/Violet3.jpg";
import violet3 from "../../assets/img/violet6.jpg";
import {useNavigate} from 'react-router-dom';
import "../../assets/css/index.css";
import {Film} from "../../models/FilmModel";
import FilmService from '../../redux/services/FilmService';

function Home() {

  const navigate = useNavigate();
  const [films, setFilms] = React.useState<Film[]>([]);

  React.useEffect(() => {
    if (films.length !== 0) return;
    FilmService.getFilms().then((res) => {
      setFilms(res);
    })
  }, [films])
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
<div className='mx-2 my-2 d-flex' style={{
  border:"2px solid #635654",
}}>
<Form>
<Form.Group className="" style={{
                 }}>
<FloatingLabel
    controlId="floatingInput"
    label="Название фильма"
    className=""
    style={{
      paddingTop:"0.5rem",
      height:"40px",
    }}
  >
                <Form.Control type="text" placeholder="Название фильма" className="" style={{
      height:"40px",
      paddingBottom:"1rem"
    }}/>
</FloatingLabel>
            </Form.Group>

</Form>
<Dropdown>
<Dropdown.Toggle className="marginSortArrow d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"0.5rem 3rem 0 3rem" ,
                            borderColor:"#D0B3AA",
                }}>
                  Сортировать 
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item>По рейтингу</Dropdown.Item>
                    <Dropdown.Item>По алфавиту</Dropdown.Item>
                    <Dropdown.Item>По длительности</Dropdown.Item>
                </Dropdown.Menu>
</Dropdown>
<Form></Form>
</div>
      <Container className='mt-4 mb-4 row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4 col-lg-11 col-md-8 mx-auto'>
        {films.map((film)=>(
            <div className='col'>
            <Card onClick={()=> {navigate("/film?id="+ film.ID)}} className="mx-4 film"
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
      }}>
        <Card.Body>
          <Image src={film.Poster}  style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
          <h3 style={{
            textAlign:"center",
          }}>{film.Name}</h3>
        </Card.Body>
      </Card>
          </div>
        ))}
      </Container>
       {/* <div className="d-flex" style={{ 
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
      </div> */}
    </div>
   
  );
}

export default Home;
