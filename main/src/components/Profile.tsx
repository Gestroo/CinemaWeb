import React from 'react';
import {Dropdown} from 'react-bootstrap';
import { Booking } from '../models/BookingModel';
import BookingService from '../redux/services/BookingService';

function Profile() {

const[key,setKey] = React.useState<boolean>(false)
const[bookings,setBookings]=React.useState<Booking[]>([])

  return (
    <div className="d-flex flex-column align-items-center" style={{
        backgroundColor: "#635654",
        color:"white",
        height:"100%",
    }}>
            <div className=''  style={{
                height:"100%",
            }}>
                <h2 className='mt-4 mx-auto'>История заказов</h2>
            <Dropdown style={{
                border:"1px solid #D0B3AA",
                borderRadius:"15px"
            }}>
                <Dropdown.Toggle style={{
                            backgroundColor: "#635654",
                            margin:"auto 3rem",
                            borderColor:"#635654",
                            fontSize:"20px"
                }}>Сортировать</Dropdown.Toggle>
                <Dropdown.Menu>
                <Dropdown.Item>По дате</Dropdown.Item>
                    <Dropdown.Item>По алфавиту</Dropdown.Item>
                    
                    <Dropdown.Item>По длительности</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>
            </div>
           
        </div>
  );
}

export default Profile;
