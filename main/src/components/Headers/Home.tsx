import React from 'react';
import {Card, Container, Carousel,Form,Dropdown,FloatingLabel, FormGroup, FormLabel} from 'react-bootstrap';
import Image from 'react-bootstrap/Image'
import "bootstrap/dist/css/bootstrap.min.css";
import violet1 from "../../assets/img/Violet2.jpg";
import violet2 from "../../assets/img/Violet3.jpg";
import violet3 from "../../assets/img/violet6.jpg";
import {useNavigate} from 'react-router-dom';
import "../../assets/css/index.css";
import {Film} from "../../models/FilmModel";
import {Genre} from "../../models/GenreModel";
import FilmService from '../../redux/services/FilmService';
import GenreService from '../../redux/services/GenreService';

function Home() {

  const [minValue,setMinValue] = React.useState<number>(0) 
  const [maxValue,setMaxValue] = React.useState<number>(200)
  const showMinValue=(e:any)=>{
    setMinValue(e.target.value)
  }
  const showMaxValue=(e:any)=>{
    setMaxValue(e.target.value)
  }
  const navigate = useNavigate();
  const [films, setFilms] = React.useState<Film[]>([]);
  const [genres, setGenres] = React.useState<Genre[]>([]);
  const [key,setKey] = React.useState<boolean>(false)

  React.useEffect(() => {
    if (key) return;
    FilmService.getFilms().then((res) => {
      setFilms(res);
    })
    GenreService.getGenres().then((res)=>{setGenres(res)})
    setKey(true)
  }, [films,genres,key])

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
<div className='my-2 d-flex' style={{
  border:"2px solid #D0B3AA",
  borderRadius:"20px",
  justifyContent:"space-between",
  paddingLeft:"8rem",
  paddingRight:"8rem"
}}>
<Form>
<Form.Group className="" style={{
  marginTop:"1rem",
  marginLeft:"1rem"
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
<Dropdown style={{
  
}}>
<Dropdown.Toggle className="marginSortArrow mt-4 d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"1rem 3rem 1rem 3rem" ,
                            borderColor:"#D0B3AA",
                            width:"65%"
                }}>
                  Сортировать 
                </Dropdown.Toggle>
                <Dropdown.Menu >
                    <Dropdown.Item>По рейтингу</Dropdown.Item>
                    <Dropdown.Item>По алфавиту</Dropdown.Item>
                    <Dropdown.Item>По длительности</Dropdown.Item>
                </Dropdown.Menu>
</Dropdown>
<Dropdown>
<Dropdown.Toggle className="marginSortArrow mt-4 d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"1rem 3rem 1rem 3rem" ,
                            borderColor:"#D0B3AA",
                }}>
                  Жанр 
                </Dropdown.Toggle>
                <Dropdown.Menu style={{
                  overflow:"scroll",
                  maxHeight:"180px",
                  overflowX:"hidden"
                }}>
                {genres.map((genre)=>(
            <Dropdown.Item>{genre.Title}</Dropdown.Item>
        ))}
                  
                </Dropdown.Menu>
</Dropdown>
<Dropdown>
<Dropdown.Toggle className="marginSortArrow mt-4 d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"1rem 3rem 1rem 3rem" ,
                            borderColor:"#D0B3AA",
                }}>
                 Ограничение
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item>0+</Dropdown.Item>
                    <Dropdown.Item>6+</Dropdown.Item>
                    <Dropdown.Item>12+</Dropdown.Item>
                    <Dropdown.Item>16+</Dropdown.Item>
                    <Dropdown.Item>18+</Dropdown.Item>
                </Dropdown.Menu>
</Dropdown>
<div style={{
  alignItems:"center",
}}>
<label style={{
  marginLeft:"4rem",
    textAlign:"center",
    color:"white",
  }}>Длительность(мин)</label>
<Form className="mx-4" style={{
  color:"white",
  marginTop:"0"
}}>
  
<FormGroup className="form-range d-flex">
<FormLabel className='mx-2'>От</FormLabel>
<FormLabel id='minDurationLabel'style={{
  width:"30px",
  textAlign:"center"
}} className='mx-2 durationValueLabel'>{minValue}</FormLabel>
<Form.Range min={0} max={200} onChange={showMinValue} value={minValue} defaultValue={0} step={1} ></Form.Range>
</FormGroup>
<FormGroup className="form-range d-flex">
<FormLabel className='mx-2 durationValueLabel'>До</FormLabel>
<FormLabel id='maxDurationLabel' style={{
  width:"30px"
}} className='mx-2'>{maxValue}</FormLabel>
<Form.Range min={minValue} max={200} onChange={showMaxValue} value={maxValue} defaultValue={200} step={1}></Form.Range>
</FormGroup>
</Form>
</div>

</div>
      <Container className='mt-4 row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4 col-lg-11 col-md-8 mx-auto'>
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
    </div>
   
  );
}

export default Home;
