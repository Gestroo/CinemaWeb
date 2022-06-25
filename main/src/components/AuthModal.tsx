import React, {useState} from "react";
import {Button,Form, Modal,InputGroup,Toast, ToastContainer } from "react-bootstrap";
import {useNavigate} from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import "../assets/css/index.css";
import {useDispatch} from "react-redux";
import {AppDispatch} from "../redux/store"
import AuthService from "../redux/services/AuthService"
import {LoginModel} from '../models/RequestModel';
import sha256 from "sha256";
import { clientActions } from "../redux/slices/clientslice";

interface AuthProps {
	open: boolean,
	handlerClose: () => void
}

function AuthModal(props: AuthProps){

    interface State {
        phone: string,
        password: string
    }

    const navigate = useNavigate();
    const logInHandleClose = () => props.handlerClose();
    const dispatch = useDispatch<AppDispatch>();
    const [show, setShow] = useState(false);
    const toggleShow = () => setShow(!show);
    const [nullShow, setNullShow] = useState(false);
    const toggleNullShow = () => setNullShow(!nullShow);
        const [values, setValues] = useState<State>({
            phone: '',
            password: ''
        });
    
        const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
            setValues({...values, [prop]: event.target.value.trim()});
        };
        const logIn = () => {
            const data: LoginModel = {
                phone: values.phone,
                password: sha256(values.password)
            };
            AuthService.login(data).then((res) => {
                dispatch(res)
                if (res.type === clientActions.loginSuccess.type) {
                    logInHandleClose();
                    navigate(0);
                }
                else {setShow(true)}
            })

        }

    return(
        <>
    <Modal show={props.open} onHide={props.handlerClose} >
        <Modal.Header closeButton style={{
            backgroundColor: "#D0B3AA",
        }}>
            <Modal.Title style={{
                fontWeight:"bold",
            }}>Вход </Modal.Title>
        </Modal.Header>
        <Modal.Body
        style={{ 
            backgroundColor: "#635654",
            color: "#fff",
        }}>
            <Form>
                <Form.Group className="my-2">
                    <Form.Label style={{
                fontWeight:"bold",
            }}>Email</Form.Label>
                        <InputGroup className="">
                            <InputGroup.Text >
                            +7
                            </InputGroup.Text>
                        <Form.Control type="text" placeholder="Введите телефон" maxLength={10} value={values.phone} onChange={e => {
                    if(!isNaN(Number(e.target.value))){
                        setValues({...values,phone:  e.target.value.trim()});
                    }
                    else{
                        setValues({...values,phone:e.target.value.substring(0, e.target.value.length - 1).trim()});
                    }
                  }} style={{
                       backgroundColor:"#D0B3AA", 
                    }}/>
                    </InputGroup>
                </Form.Group>
                <Form.Group className="my-2">
                    <Form.Label style={{
                fontWeight:"bold",
            }}>Пароль</Form.Label>
                    <Form.Control type="password" onChange={handleChange("password")} placeholder="Введите пароль" style={{
    backgroundColor:"#D0B3AA",
    color:"000",
                    }}/>
                </Form.Group>
            </Form>
            <div className="d-flex" style={{
                alignItems:"center",
            }}>
            <Button onClick={logIn} className="mt-4" style={{
                backgroundColor:"#D0B3AA",
                borderColor: "#D0B3AA",
                color:"#000",
                fontWeight:"bold",
            }}> Войти</Button>
            <div style={{
                alignItems:"center",
                marginTop:"1rem",
            }}>
            <a href="" onClick={()=> {navigate("/registration")}}  className=" mx-4 regref" style={{
            }}>Зарегистрироваться</a>
            </div>
            </div>
            
            
        </Modal.Body>
    </Modal>
    <ToastContainer position="top-end">
    <Toast show={show} bg="danger" autohide delay={3000} onClose={toggleShow}>
    <Toast.Header>
        <strong>Ошибка</strong>
    </Toast.Header>
    <Toast.Body>Неверный телефон или пароль</Toast.Body>
  </Toast>
    </ToastContainer>
    <ToastContainer>
    <Toast show={nullShow} bg="danger" autohide delay={3000} onClose={toggleNullShow}>
    <Toast.Header>
        <strong>Ошибка</strong>
    </Toast.Header>
    <Toast.Body>Заполните все поля</Toast.Body>
  </Toast>
    </ToastContainer>
   
  </>)
}



export default AuthModal;