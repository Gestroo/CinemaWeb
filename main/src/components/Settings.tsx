import {Dropdown,Form,Button} from 'react-bootstrap';
import { RootState} from "../redux/store";
import { useSelector} from "react-redux";



function Settings() {
    const user = useSelector((state: RootState) => state);

    return (
      <div className="" style={{
          backgroundColor:"#635654",
          color:"white",
    }}>
          <h2 className="pt-4 " style={{
              margin:"0 auto",
              justifyContent:"center",
              textAlign:"center",
          }}>Настройки</h2>
          <div className="d-flex" style={{
              backgroundColor:"#635654",
          margin: "0 auto",
          border:"2px solid #635654",
          borderRadius: "15px",
          width: "29%",
          flexDirection:"column"
      }}>
          <Form className="mx-4 my-2 d-flex" style={{
              flexDirection:"column",
          }}>
        <Form.Group className="my-2">
                <Form.Label>Фамилия</Form.Label>
                <Form.Control type="text" placeholder="Фамилия" defaultValue={user.client.client!.lastname}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Имя</Form.Label>
                <Form.Control type="text"  placeholder="Имя" defaultValue={user.client.client!.firstname}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Отчество (необязательно)</Form.Label>
                <Form.Control type="text"  placeholder="Отчество" defaultValue={user.client.client!.middlename}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Email</Form.Label>
                <Form.Control type="email"  placeholder="Введите email" defaultValue={user.client.client!.email}/>
            </Form.Group>
        <Form.Group className="my-2">
                <Form.Label>Телефон</Form.Label>
                <Form.Control type="text" placeholder="Телефон" defaultValue={user.client.client!.phone}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Пароль</Form.Label>
                <Form.Control type="password"  placeholder="Введите пароль"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control type="password" placeholder="Повторите пароль" />
            </Form.Group>
            <Button variant="primary" className='mt-4' style={{
                width: "50%",
                margin:"0 auto"
            }}>Сохранить</Button>
        </Form>
          </div>
         
      </div>
    );
  }
  
  export default Settings;