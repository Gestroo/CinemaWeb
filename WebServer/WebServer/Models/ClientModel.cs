﻿using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        public string birthdate { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public ClientModel(int id, string date, string lastname, string firstname, string middlename, string phone, string email)
        {
            this.id = id;
            this.birthdate = date;
            this.lastname = lastname;
            this.firstname = firstname; 
            this.middlename = middlename;
            this.phone = phone; 
            this.email = email;
        }
        public ClientModel(Client c) {
            this.id = c.ID;
            this.birthdate = c.BirthDate.ToString();
            this.lastname = c.LastName;
            this.firstname = c.FirstName;
            this.middlename = c.MiddleName;
            this.phone = c.PhoneNumber;
            this.email = c.Email;
        }
        public ClientModel (){}
    }
    
}
