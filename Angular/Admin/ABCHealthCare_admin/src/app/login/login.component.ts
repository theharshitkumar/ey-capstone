import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { admin_login } from './admin_login';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit{

  Admin_login:admin_login[] ;
  admin = new admin_login();
  
  constructor(private apiService:ApiService , private router: Router) {}

 
  ngOnInit() {
  }
 /*
  refreshPeople() {
    this.apiService.getPeople()
      .subscribe(data => {
        console.log(data)
        this.people=data;
      })      
 
  }
  */
  gotoHome() {
    this.router.navigate(['../home']);
  }
 
  authenticate_admin() {
   var result =  this.apiService.authenticate_admin(this.admin)
      .subscribe(data => {
        console.log(data)
      })
      if(localStorage.getItem('access_token'))
      {this.gotoHome();}
  }


}
