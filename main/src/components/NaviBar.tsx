import React, {useState} from "react";
import { Navbar,Button,Image,Form, Nav, Modal } from "react-bootstrap";
import {useNavigate} from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import img from "../assets/img/logo.png";
import "../assets/css/index.css";


export default function Navibar(){
    const navigate = useNavigate();
    const [show,setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

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
            <Button className="mx-1" onClick={()=> {handleShow()}} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    }}>
            Войти    
            </Button>
            <Button className="mx-3" onClick={()=> {}} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    }}>
            Зарегистрироваться  
            </Button>
        </Nav>
    </Navbar.Collapse>
</Navbar>
<Modal show={show} onHide={handleClose}>
    <Modal.Header closeButton>
        <Modal.Title>Вход </Modal.Title>
    </Modal.Header>
    <Modal.Body>
        <Form>
            <Form.Group>
                <Form.Label>Email</Form.Label>
                <Form.Control type="email" placeholder="Введите email"/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Введите пароль"/>
            </Form.Group>
        </Form>
        <Button className="mt-4" variant="primary"> Войти</Button>
    </Modal.Body>
</Modal>
</>
)
    
}