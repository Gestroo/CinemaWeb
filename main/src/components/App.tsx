import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css"
import ReactDOM from 'react-dom';
import NaviBar from "./NaviBar";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from "./Home"
import Discount from "./Discount"
import News from "./News"
import About from "./About"

function App() {
  return (
   <NaviBar/>

  );
}

export default App;