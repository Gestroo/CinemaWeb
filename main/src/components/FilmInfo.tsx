import React from 'react';
import {Button, Card,Image,Container} from 'react-bootstrap';
import {useNavigate, useLocation} from 'react-router-dom';
import joker from "../assets/img/joker.png";
import FilmService from '../redux/services/FilmService';
import SeanceService from '../redux/services/SeanceService';
import {Film} from '../models/FilmModel'
import {Seance} from '../models/SeanceModel'


function FilmInfo() {
  const navigate = useNavigate();
  const [film, setFilm] = React.useState<Film>();
  const [seances, setSeances] = React.useState<Seance[]>([]);
  const {search} = useLocation();
  const searchParams = new URLSearchParams(search);
  const filmId = searchParams.get("id");
  let key = false;


  React.useEffect(() => {
    if (key) return;
    FilmService.getFilmById(filmId!).then((res) => {
      if(res!== undefined){
        setFilm(res);
      }
    })
    SeanceService.getSeanceById(filmId!).then((res) => {
      setSeances(res);
    })
    key = true;
  }, [film, seances])
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
          <Image src={film?.Poster}  style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
        </Card.Body>
        </Card>
        <div>
        <div className='d-flex'>
        <h2 className='my-2' style={{
            color:"#fff"
        }}>
           {film?.Name}
        </h2>
        <Button onClick={() => {navigate("/tickets")}} className="mx-4 mt-2" style={{
          color:"white",
          fontWeight: "bold",
            backgroundColor: "#D0B3AA",
            borderColor: "#D0B3AA",
            height:'40px'}}>
          Купить билеты
        </Button>
        
        </div>
        
          <div>
            <h4>
              Жанр: {film?.Genre.Title}
            </h4>
          <h5>
            Ограничение : {film?.Restriction}+
          </h5>
          <h6>
            Длительность: {film?.Duration} мин.
          </h6>

          <p>
            {film?.Description}
          </p>
          <Container className='mt-4 mb-4 row row-cols-1 row-cols-sm-2 row-cols-md-5 g-5 col-lg-11 col-md-8 mx-auto'>
        {seances.map((seance)=>(
            <div className='col'>
            <Card className="mx-4 "
       style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
      }}>
        <Card.Body>

          <h3 style={{
            textAlign:"center",
          }}>{seance.SeanceDate.getHours}:{seance.SeanceDate.getMinutes}</h3>
          <h6 style={{
            textAlign:"center",
          }}>
            {seance.CinemaHall.HallName}
          </h6>
        </Card.Body>
      </Card>
          </div>
        ))}
      </Container>
          </div>

        </div>
        
        
        
      </div>
  );
}

export default FilmInfo;