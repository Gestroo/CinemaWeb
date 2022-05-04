import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from "./components/Home"
import Discount from "./components/Discount"
import News from "./components/News"
import About from "./components/About"
import Navibar from './components/NaviBar';
import "bootstrap/dist/css/bootstrap.min.css"

function App() {
 return(
   <>
      <Navibar/>
   </>  
 )
}

ReactDOM.render(
  <BrowserRouter>
      <App/>

  <Routes>
    <Route path="/" element={<Home />}></Route>
    <Route path="/news" element={<News/>}></Route>
    <Route path="/discounts" element={<Discount />}></Route>
    <Route path="/about" element={<About />}></Route>  
  </Routes>
</BrowserRouter>,
document.getElementById("root")
);


reportWebVitals();
