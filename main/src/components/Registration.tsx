import React, {useState} from 'react';
import {Form,Button} from 'react-bootstrap';
import {useDispatch} from "react-redux";
import {AppDispatch} from "../redux/store";
import AuthService from "../redux/services/AuthService";
import {RegisterSuccess} from "../redux/actions/authActions";
import {RegistrationModel} from "../models/RequestModel";
import sha256 from "sha256";
import {useNavigate} from 'react-router-dom';


interface State {
	lastname: string,
	firstname: string,
	phone: string,
	middlename: string,
    birthdate:string,
	email: string,
	mainpassword: string,
	passwordcheck: string
}

function Registration() {
    const dispatch = useDispatch<AppDispatch>();
    const [values, setValues] = useState<State>({
        lastname: '',
        firstname: '',
        phone: '',
        middlename: '',
        birthdate:'',
        email: '',
        mainpassword: '',
        passwordcheck: ''
    })
    const navigate = useNavigate();
    const signUp = (event: any) => {
		if (values.mainpassword !== values.passwordcheck) return;
		const data: RegistrationModel = {
			password: sha256(values.mainpassword),
			lastname: values.lastname,
			firstname: values.firstname,
			phone: values.phone,
			middlename: values.middlename,
            birthdate: values.birthdate,
			email: values.email
		};
		AuthService.register(data).then((res) => {
			dispatch(res)
			if (res.type === RegisterSuccess.type){
				navigate("/");
			}
		});
	};

    const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
		setValues({...values, [prop]: event.target.value.trim()});
	};
  return (
    <div className="mt-2" style={{ 
    }}>
    <h1 className="" style={{
          margin: "0 auto", 
          justifyContent:"", 
          width: "29%",
          textAlign:"center",    
      }}>Регистрация</h1>
      <div className="mt-4" style={{
          margin: "0 auto",
          border:"2px solid #635654",
          borderRadius: "15px",
          width: "29%",
          backgroundColor:"#ffffff"
      }}>
      <div className="d-flex" >
        <Form className="mx-4 my-2">
        <Form.Group className="my-2">
                <Form.Label>Фамилия</Form.Label>
                <Form.Control type="text" onChange={handleChange("lastname")} value={values.lastname} placeholder="Фамилия"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Имя</Form.Label>
                <Form.Control type="text" onChange={handleChange("firstname")} value={values.firstname} placeholder="Имя"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Отчество (необязательно)</Form.Label>
                <Form.Control type="text" onChange={handleChange("middlename")} value={values.middlename} placeholder="Отчество"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Email</Form.Label>
                <Form.Control type="email" onChange={handleChange("email")} value={values.email} placeholder="Введите email"/>
            </Form.Group>
        </Form>
        <Form className="mx-4 my-2">
        <Form.Group className="my-2">
                <Form.Label>Телефон</Form.Label>
                <Form.Control type="text" onChange={handleChange("phone")} value={values.phone} placeholder="Телефон"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Дата рождения</Form.Label>
                <Form.Control type="date" onChange={handleChange("birthdate")} value={values.birthdate} placeholder="Дата рождения"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Пароль</Form.Label>
                <Form.Control type="password" onChange={handleChange("mainpassword")} value={values.mainpassword} placeholder="Введите пароль"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control type="password" onChange={handleChange("passwordcheck")} value={values.passwordcheck} placeholder="Повторите пароль"/>
            </Form.Group>
        </Form>
        
            </div>
            <div style={{
                width:"100%"
            }}>
            <Button onClick={signUp} className="my-2" variant="primary"  style={{
                marginLeft:"11rem"
            }}>Зарегистрироваться</Button>
            </div>
            
        </div>
    </div>
  );
}

export default Registration;