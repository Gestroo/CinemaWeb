import React from 'react';
import {Dropdown} from 'react-bootstrap';

function Profile() {
  return (
    <div className="d-flex" style={{
        backgroundColor: "#635654",
        color:"white"}}>
            <div style={{
                border:"1px",
                borderRight:"2px solid",
                borderColor:"white",
            }}>
            <Dropdown>
                <Dropdown.Toggle style={{
                            backgroundColor: "#635654",
                            margin:"auto 3rem",
                            borderColor:"#635654",
                }}>Сортировать</Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item>По алфавиту</Dropdown.Item>
                    <Dropdown.Item>По рейтингу</Dropdown.Item>
                    <Dropdown.Item>По длительности</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>
            </div>
            <div>
                <h3>История заказов</h3>
            </div>
        </div>
  );
}

export default Profile;
