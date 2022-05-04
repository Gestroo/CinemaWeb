import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import {Link} from "react-router-dom";


export default function Navibar(){
    return(
    <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark" >
    <Navbar.Brand>Кинотеатр Премьер</Navbar.Brand>
    <Navbar.Toggle aria-controls="responsive-navbar-bar"/>
    <Navbar.Collapse id="responsive-navbar-bar">
        <Nav className="mr-auto">
            <Nav.Link><Link to="/">Фильмы</Link></Nav.Link>
            <Nav.Link><Link to="/news">Новости</Link></Nav.Link>
            <Nav.Link><Link to="/discounts">Акции</Link></Nav.Link>
            <Nav.Link><Link to="/about">О нас</Link></Nav.Link>
        </Nav>
    </Navbar.Collapse>
</Navbar>
)
    
}