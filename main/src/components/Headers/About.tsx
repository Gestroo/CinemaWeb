import React from 'react';
import {Card} from 'react-bootstrap';

function About() {
  return (
    <div>
       <h2 className='mt-4' style={{ 
        backgroundColor:"#635654",
        color:"#fff",
        textAlign:"center", }}>
О нас
       </h2>
       <h4 className="mt-4" style={{ 
        backgroundColor:"#635654",
        color:"#fff",
        textAlign:"center", }}>
        Веб-приложение разработано студентом группы ИТб-2301 Широковым Дмитрием Романовичем при поддержке Земцова М.А.
       </h4>
    </div>
  );
}

export default About;
