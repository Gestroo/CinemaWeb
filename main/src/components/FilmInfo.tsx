import React from 'react';
import {Card,Image,Container,Button} from 'react-bootstrap';
import {useNavigate, useLocation} from 'react-router-dom';
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
  const [key,setKey] = React.useState<boolean>(false)


  React.useEffect(() => {
    if (key) return;
    FilmService.getFilmById(filmId!).then((res) => {
      if(res!== undefined){
        setFilm(res);
      }
    })
    SeanceService.getSeanceByFilmId(filmId!).then((res) => {
      setSeances(res);
    })
    setKey(true);
  }, [film, seances,key])
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
        width:"320px"
      }}>
        <Card.Body>
          <Image src={film?.poster} style={{
            width:"270px",
            height:"360px"
          }}>
          </Image>
        </Card.Body>
        </Card>
        <div style={{
          width:"90%"
        }}>
        <div className='mx-4'>
        <h2 className='my-2' style={{
            color:"#fff"
        }}>
           {film?.name}
        </h2>
        <div>
            <h4>
              Жанр: {film?.genre.title}
            </h4>
          <h5>
            Ограничение : {film?.restriction}+
          </h5>
          <h6>
            Длительность: {film?.duration} мин.
          </h6>

          <p>
            Описание фильма: {film?.description}
          </p>
        </div>
        
          
          <Container className='mt-4 mb-4 row row-cols-1 row-cols-sm-5 row-cols-md-5 g-5 col-lg-11 col-md-8 mx-auto' style={{
            width:"100%"
          }}>
        {seances.map((seance)=>(
            <Card onClick={()=> {navigate("/tickets?id="+ seance.id)}} className="mx-4 seance"
                  style={{
        backgroundColor: "#635654",
        borderColor: "#635654",
        color:"#fff",
        width:"200px",
        border:"2px solid #D0B3AA",
        borderRadius:"15px",
      }}>
        <Card.Body>
          <h5 style={{
            textAlign:"center",
          }}>{seance.seanceDate} </h5>
          <h3 style={{
            textAlign:"center",
          }}>{seance.seanceTime}</h3>
          <h6 style={{
            textAlign:"center",
          }}>
            {seance.cinemaHall.hallName}
          </h6>
        </Card.Body>
      </Card>
        ))}
      </Container>
          </div>

        </div>
        
        
        
      </div>
  );
}

export default FilmInfo;