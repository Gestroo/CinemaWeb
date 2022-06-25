import React, {useState} from "react";
import { Navbar,Button,Image, Nav,Dropdown } from "react-bootstrap";
import {useNavigate} from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import img from "../assets/img/logo.png";
import "../assets/css/index.css";
import { useSelector} from "react-redux";
import { RootState} from "../redux/store";
import {useDispatch} from "react-redux";
import {AppDispatch} from "../redux/store"
import AuthService from "../redux/services/AuthService"
import AuthModal from "./AuthModal";

    export default function Navibar(){
        
        const [open, setOpen] = React.useState(false);
    const navigate = useNavigate();
    const user = useSelector((state: RootState) => state);
    const dispatch = useDispatch<AppDispatch>();
    
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
            <Button className="mx-1 noBorder" name={"auth"} onClick={() => setOpen(true)} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    fontWeight:"bold",
    }}>
            Войти    
            </Button>
            <Button className="mx-3" onClick={()=> {navigate("/registration")}} style={{
    backgroundColor: "#635654",
    borderColor: "#635654",
    fontWeight:"bold",
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
                    <Dropdown.Item onClick={()=> {navigate("/myreviews")}}>Мои отзывы</Dropdown.Item>
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
<AuthModal open={open} handlerClose={() => setOpen(false)}/>
</>
)
        }
