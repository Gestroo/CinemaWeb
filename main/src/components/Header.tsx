import React, {useState} from "react";
import { Navbar,Button,Image,Form, Nav, Modal,Dropdown,InputGroup } from "react-bootstrap";
import {useNavigate} from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import img from "../assets/img/logo.png";
import "../assets/css/index.css";
import { useSelector} from "react-redux";
import { RootState} from "../redux/store";
import {useDispatch} from "react-redux";
import {AppDispatch} from "../redux/store"
import AuthService from "../redux/services/AuthService"
import {LoginModel} from '../models/RequestModel';
import sha256 from "sha256";
import { clientActions } from "../redux/slices/clientslice";

    export default function Navibar(){
        interface State {
            phone: string,
            password: string
        }
    
    const navigate = useNavigate();
    const [logInShow,setLogInShow] = useState(false);
    const logInHandleClose = () => setLogInShow(false);
    const logInHandleShow = () => setLogInShow(true);
    const user = useSelector((state: RootState) => state);
    const dispatch = useDispatch<AppDispatch>();
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

    <Navbar.Brand className="logoButton" onClick={() => {navigate("/")}} style={{
        fontWeight:"bold"
    }} >
        <Image src={img} className="mx-3" style={{
            width: "60px",
        }}>
            </Image> 
            Кинотеатр Премьер</Navbar.Brand>
    <Navbar.Toggle aria-controls="responsive-navbar-bar">
    
    </Navbar.Toggle>
    <Navbar.Collapse id="responsive-navbar-bar">
        <Nav className="mx-auto" style={{
            fontSize: "20px",
            color:"black",
            fontWeight:"bold"
        }}>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/")}}>Фильмы</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/news")}}>Новости</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/discounts")}}>Акции</Nav.Link>
            <Nav.Link   className="mx-3" onClick={() => {navigate("/about")}}>О нас</Nav.Link>
        </Nav>
        <Nav>
            {!user.client.isAuth?(
        
                <>
            <Button className="mx-1 noBorder" onClick={()=> {logInHandleShow()}} style={{
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
                <Dropdown.Toggle className="marginArrow d-flex" style={{
                            backgroundColor: "#D0B3AA",
                            margin:"auto 3rem",
                            borderColor:"#D0B3AA",
                }}>
                    <h5 style={{
                        marginTop:"0.5rem",
                        color:"black",
                    }}> {user.client.client!.firstname}</h5>
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item onClick={()=> {navigate("/profile/tickethistory")}}>История заказов</Dropdown.Item>
                    <Dropdown.Item onClick={()=> {navigate("/profile/settings")}}>Настройки</Dropdown.Item>
                    <Dropdown.Divider />
                    <Dropdown.Item onClick={()=>{dispatch(AuthService.logout());
                    navigate("/")
                    }}>Выйти</Dropdown.Item>
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
                    <InputGroup className="">
                        <InputGroup.Text >
                        +7
                        </InputGroup.Text>
                    <Form.Control type="text" placeholder="Введите телефон" onChange={handleChange("phone")} style={{
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
</>
)
        }
