import React from 'react';
import {Card, Container, Carousel,Form,Dropdown,FloatingLabel, FormGroup, FormLabel} from 'react-bootstrap';
import Image from 'react-bootstrap/Image'
import "bootstrap/dist/css/bootstrap.min.css";
import ad1 from "../../assets/img/ad.jpg"
import {useNavigate} from 'react-router-dom';
import "../../assets/css/index.css";
import {Film} from "../../models/FilmModel";
import {Genre} from "../../models/GenreModel";
import FilmService from '../../redux/services/FilmService';
import GenreService from '../../redux/services/GenreService';

function Home() {
  const [title,setTitle] = React.useState<string>("");
  const [option,setOption] = React.useState<number>(0);
  const [genre,setGenre] = React.useState<string>("");
  const [restriction,setRestriction] = React.useState<number>(19);
  const [minValue,setMinValue] = React.useState<number>(0) ;
  const [maxValue,setMaxValue] = React.useState<number>(200);
  const showMinValue=(e:any)=>{
    setMinValue(e.target.value);
    filterFilms(title,option,genre,restriction,e.target.value,maxValue)
  }
  const showMaxValue=(e:any)=>{
    setMaxValue(e.target.value)
    filterFilms(title,option,genre,restriction,minValue,e.target.value)
  }
  const filterFilms = (title:string,option:number,genre:string,restriction:number,minDuration:number,maxDuration:number)=>{
    FilmService.filterFilms(title,option,genre,restriction,minDuration,maxDuration).then((res) => {
      console.log(res);
      setFilms(res);
    })
  }
  const navigate = useNavigate();
  const [films, setFilms] = React.useState<Film[]>([]);
  const [genres, setGenres] = React.useState<Genre[]>([]);
  const [key,setKey] = React.useState<boolean>(false);

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
        <Carousel variant="dark" className="mx-auto my-4"  fade style={{
          width:"640px",
          backgroundColor:"#000"
        }}>
          <Carousel.Item>
              <Image src={ad1} style={{
                width:"640px",
                height:"360px",
              }}></Image>
            </Carousel.Item>
            <Carousel.Item>
              <Image src={ad1} style={{
                width:"640px",
                height:"360px",
              }}></Image>
            </Carousel.Item>
            <Carousel.Item>
              <Image src={ad1} style={{
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
    label="???????????????? ????????????"
    className=""
    style={{
      paddingTop:"0.5rem",
      height:"40px",
    }}
  >
                <Form.Control type="text" value={title} onChange={e=>{setTitle(e.target.value);filterFilms(e.target.value,option,genre,restriction,minValue,maxValue)}} placeholder="???????????????? ????????????" className="" style={{
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
                            fontWeight:"bold",
                            width:"65%",
                            color:"#000"
                }}>
                  ?????????????????????? 
                </Dropdown.Toggle >
                <Dropdown.Menu   >
                    <Dropdown.Item onClick={e=>{setOption(1);filterFilms(title,1,genre,restriction,minValue,maxValue)}} value={1}>???? ????????????????</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setOption(2);filterFilms(title,2,genre,restriction,minValue,maxValue)}} value={2}>???? ????????????????</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setOption(3);filterFilms(title,3,genre,restriction,minValue,maxValue)}} value={3}>???? ????????????????????????</Dropdown.Item>
                </Dropdown.Menu>
</Dropdown>
<Dropdown>
<Dropdown.Toggle className="marginSortArrow mt-4 d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"1rem 3rem 1rem 3rem" ,
                            borderColor:"#D0B3AA",
                            fontWeight:"bold",
                            color:"#000"
                }}>
                  ???????? 
                </Dropdown.Toggle>
                <Dropdown.Menu style={{
                  overflow:"scroll",
                  maxHeight:"180px",
                  overflowX:"hidden"
                }}>
                {genres.map((genre)=>(
            <Dropdown.Item onClick={e=>{setGenre(genre.Title);filterFilms(title,option,genre.Title,restriction,minValue,maxValue)}}>{genre.Title}</Dropdown.Item>
        ))}
                  
                </Dropdown.Menu>
</Dropdown>
<Dropdown>
<Dropdown.Toggle className="marginSortArrow mt-4 d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"1rem 3rem 1rem 3rem" ,
                            borderColor:"#D0B3AA",
                            fontWeight:"bold",
                            color:"#000"
                }}>
                 ??????????????????????
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item onClick={e=>{setRestriction(0);filterFilms(title,option,genre,0,minValue,maxValue)}} value={0}>0+</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setRestriction(6);filterFilms(title,option,genre,6,minValue,maxValue)}} value={6}>6+</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setRestriction(12);filterFilms(title,option,genre,12,minValue,maxValue)}} value={12}>12+</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setRestriction(16);filterFilms(title,option,genre,16,minValue,maxValue)}} value={16}>16+</Dropdown.Item>
                    <Dropdown.Item onClick={e=>{setRestriction(18);filterFilms(title,option,genre,18,minValue,maxValue)}} value={18}>18+</Dropdown.Item>
                </Dropdown.Menu>
</Dropdown>
<div style={{
  alignItems:"center",
}}>
<label style={{
  marginLeft:"4rem",
    textAlign:"center",
    color:"white",
  }}>????????????????????????(??????)</label>
<Form className="mx-4" style={{
  color:"white",
  marginTop:"0"
}}>
  
<FormGroup className="form-range d-flex">
<FormLabel className='mx-2'>????</FormLabel>
<FormLabel id='minDurationLabel'style={{
  width:"30px",
  textAlign:"center"
}} className='mx-2 durationValueLabel'>{minValue}</FormLabel>
<Form.Range min={0} max={200} onChange={showMinValue} value={minValue} defaultValue={0} step={1} ></Form.Range>
</FormGroup>
<FormGroup className="form-range d-flex">
<FormLabel className='mx-2 durationValueLabel'>????</FormLabel>
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
            width:"270px",
            textAlign:"center",
            margin:"auto 0"
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
