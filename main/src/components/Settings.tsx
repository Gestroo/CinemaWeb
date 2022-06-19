import React from 'react';
import {Form,Button, InputGroup} from 'react-bootstrap';
import { RootState} from "../redux/store";
import { useSelector} from "react-redux";
import moment from 'moment';
import ClientService from '../redux/services/ClientService';
import { Client } from '../models/ClientModel';


function Settings() {
    const user = useSelector((state: RootState) => state);
    const [values, setValues] = React.useState<Client>({
        id:0,
        birthdate:user.client.client!.birthdate,
        lastname: user.client.client!.lastname,
        firstname:user.client.client!.firstname,
        middlename: user.client.client!.middlename,
        phone: user.client.client!.phone,
        email: user.client.client!.email,
    })

    
    const [stringDate,setStringDate] = React.useState<string>();
    const editUser=()=>{
		const data: Client = {
            id:user.client.client!.id,
            birthdate: values.birthdate,
			lastname: values.lastname,
			firstname: values.firstname,
            middlename: values.middlename,
			phone: values.phone,
			email: values.email
		};
        ClientService.editClient(data);
    }
    React.useEffect(() => {
        const date = moment(user.client.client!.birthdate, 'DD-MM-YYYY').toDate();
        setStringDate(moment(date).format("YYYY-MM-DD"));
    })
    const handleChange = (prop: keyof Client) => (event: React.ChangeEvent<HTMLInputElement>) => {
		setValues({...values, [prop]: event.target.value.trim()});
	};
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
                <Form.Control type="text" onChange={handleChange("lastname")} placeholder="Фамилия" defaultValue={user.client.client!.lastname}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Имя</Form.Label>
                <Form.Control type="text" onChange={handleChange("firstname")} placeholder="Имя" defaultValue={user.client.client!.firstname}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Отчество (необязательно)</Form.Label>
                <Form.Control type="text" onChange={handleChange("middlename")}  placeholder="Отчество" defaultValue={user.client.client!.middlename}/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Email</Form.Label>
                <Form.Control type="email" onChange={handleChange("email")} placeholder="Введите email" defaultValue={user.client.client!.email}/>
            </Form.Group>
        <Form.Group className="my-2">
            
                <Form.Label>Телефон</Form.Label>
                <InputGroup className="">
                    <InputGroup.Text >
                    +7
                    </InputGroup.Text>
                    <Form.Control type="text" onChange={e => {
                    if(!isNaN(Number(e.target.value))){
                        setValues({...values,phone:  e.target.value.trim()});
                    }
                    else{
                        setValues({...values,phone:e.target.value.substring(0, e.target.value.length - 1).trim()});
                    }
                  }} value={values.phone} placeholder="Телефон" defaultValue={user.client.client!.phone}/>
                </InputGroup>
                
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Дата родждения</Form.Label>
                <Form.Control type="date" onChange={handleChange("birthdate")} placeholder="Повторите пароль" defaultValue={ stringDate} />
            </Form.Group>
            <Button onClick={editUser} variant="primary" className='mt-4' style={{
                width: "50%",
                margin:"0 auto"
            }}>Сохранить</Button>
        </Form>
          </div>
         
      </div>
    );
  }
  
  export default Settings;