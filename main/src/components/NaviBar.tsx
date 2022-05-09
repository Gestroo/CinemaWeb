import React, {useState} from "react";
import { Navbar,Button,Image,Form, Nav, Modal, DropdownButton,Dropdown } from "react-bootstrap";
import {useNavigate} from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import img from "../assets/img/logo.png";
import "../assets/css/index.css";
import { useSelector} from "react-redux";
import { RootState} from "../redux/store";
import {useDispatch} from "react-redux";
import {AppDispatch} from "../redux/store"
import AuthService from "../redux/services/AuthService"
import {LoginSuccess} from "../redux/actions/authActions";
import {LoginModel} from '../models/RequestModel';
import sha256 from "sha256";


    export default function Navibar(){
        interface State {
            email: string,
            password: string
        }
    
    const navigate = useNavigate();
    const [logInShow,setLogInShow] = useState(false);
    const [signUpShow,setSignUpShow] = useState(false);
    const logInHandleClose = () => setLogInShow(false);
    const logInHandleShow = () => setLogInShow(true);
    const signUpHandleClose = () => setSignUpShow(false);
    const user = useSelector((state: RootState) => state);
    const dispatch = useDispatch<AppDispatch>();
        const [values, setValues] = useState<State>({
            email: '',
            password: ''
        });
    
        const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
            setValues({...values, [prop]: event.target.value.trim()});
        };
        const logIn = () => {
            const data: LoginModel = {
                email: values.email,
                password: sha256(values.password)
            };
            AuthService.login(data).then((res) => {
                dispatch(res)
                if (res.type === LoginSuccess.type) {
                    navigate("/");
                }
            })
        }

    return(
        <>
    <Navbar collapseOnSelect expand="lg" style={{
    backgroundColor: "#D0B3AA",
    color : "black",
    justifyContent: "space-between"
    }} >  

    <Navbar.Brand>
        <Image src={img} className="mx-3" style={{
            width: "60px",
        }}>
            </Image> 
            Кинотеатр Премьер</Navbar.Brand>
    <Navbar.Toggle aria-controls="responsive-navbar-bar"/>
    <Navbar.Collapse id="responsive-navbar-bar">
        <Nav className="mx-auto" style={{
            fontSize: "20px",
            
        }}>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/")}}>Фильмы</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/news")}}>Новости</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/discounts")}}>Акции</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/about")}}>О нас</Nav.Link>
        </Nav>
        <Nav>
            {!user.auth?(
                <>
            <Button className="mx-1" onClick={()=> {logInHandleShow()}} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    }}>
            Войти    
            </Button>
            <Button className="mx-3" onClick={()=> {navigate("/registration")}} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    }}>
            Зарегистрироваться  
            </Button>
            </>):(
            <Dropdown>
                <Dropdown.Toggle style={{
                            backgroundColor: "#635654",
                            margin:"auto 3rem",
                            borderColor:"#635654",
                }}>Профиль</Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item onClick={()=> {navigate("/profile/tickethistory")}}>История заказов</Dropdown.Item>
                    <Dropdown.Item>Настройки</Dropdown.Item>
                    <Dropdown.Divider />
                    <Dropdown.Item onClick={()=>dispatch(AuthService.logout())}>Выйти</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>) }
        </Nav>
    </Navbar.Collapse>
</Navbar>
<Modal show={logInShow} onHide={logInHandleClose} >
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
                <Form.Control type="email" onChange={handleChange("email")} placeholder="Введите email" style={{
                   backgroundColor:"#D0B3AA", 
                }}/>
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
        <Button onClick={logIn} className="mt-4" style={{
            backgroundColor:"#D0B3AA",
            borderColor: "#D0B3AA",
            color:"#000",
            fontWeight:"bold",
        }}> Войти</Button>
    </Modal.Body>
</Modal>
<Modal show={signUpShow} onHide={signUpHandleClose} >
    <Modal.Header closeButton>
        <Modal.Title>Регистрация </Modal.Title>
    </Modal.Header>
    <Modal.Body >
        <div className="d-flex">
        <Form>
        <Form.Group className="my-2">
                <Form.Label>Фамилия</Form.Label>
                <Form.Control type="text" placeholder="Фамилия"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Имя</Form.Label>
                <Form.Control type="text" placeholder="Имя"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Отчество (необязательно)</Form.Label>
                <Form.Control type="text" placeholder="Отчество"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label >Email</Form.Label>
                <Form.Control type="email" placeholder="Введите email"/>
            </Form.Group>
        </Form>
        <Form className="mx-4">
        <Form.Group className="my-2">
                <Form.Label>Телефон</Form.Label>
                <Form.Control type="text" placeholder="Телефон"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Пароль</Form.Label>
                <Form.Control type="password" placeholder="Введите пароль"/>
            </Form.Group>
            <Form.Group className="my-2">
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control type="password" placeholder="Повторите пароль"/>
            </Form.Group>
            <Button variant="primary"  style={{
                marginTop: "2rem",
                marginLeft: "1rem",
            }}>Зарегистрироваться</Button>
        </Form>
        </div>
    </Modal.Body>
</Modal>
</>
)
        }
