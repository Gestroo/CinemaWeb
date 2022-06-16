import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from "./components/Headers/Home"
import Discount from "./components/Headers/Discount"
import News from "./components/Headers/News"
import About from "./components/Headers/About"
import Header from './components/Header';
import Registration from './components/Registration';
import "bootstrap/dist/css/bootstrap.min.css"
import FilmInfo from './components/FilmInfo';
import Profile from './components/Profile';
import Hall1 from "./components/Hall1"
import {Provider} from "react-redux";
import {store} from './redux/store';
import Settings from './components/Settings';
import Review from './components/Review';
import MyReviews from './components/MyReviews';

function App() {
 return(
   <>
      <Header/>
   </>  
 )
}

ReactDOM.render(
<Provider store={store}>
  <BrowserRouter>
      <App/>

  <Routes>
    <Route path="/" element={<Home />}></Route>
    <Route path="/news" element={<News/>}></Route>
    <Route path="/discounts" element={<Discount />}></Route>
    <Route path="/about" element={<About />}></Route>  
    <Route path="/registration" element={<Registration/>}></Route>
    <Route path="/film" element={<FilmInfo/>}></Route>   
    <Route path="/profile/tickethistory" element={<Profile/>}></Route>   
    <Route path="/tickets" element={<Hall1/>}></Route> 
    <Route path="/profile/settings" element={<Settings/>}></Route>
    <Route path="/review" element={<Review/>}></Route>
    <Route path="/myreviews" element={<MyReviews/>}></Route>
  </Routes>
</BrowserRouter>
</Provider>,
document.getElementById("root")
);


reportWebVitals();
