
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { admin_login, token_response } from './admin_login';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

 
@Injectable({providedIn:'root'})


export class ApiService {
 
  baseURL: string = "http://localhost:11963/token";
 
  constructor(private http: HttpClient) {
  }
 
  
 
   authenticate_admin(Admin_login:admin_login): Observable<any> {
    const headers = { 'content-type': 'x-www-form-urlencoded'}  
    var input = {username: Admin_login.username , password:Admin_login.password , grant_type:"password"};
    const body3 = new URLSearchParams(input).toString();
    //var result3 = this.http.post<token_response>(this.baseURL,body3,{'headers':headers});

    var result3 = this.http.post(this.baseURL,body3,{'headers':headers})
    .pipe(
      tap(response => {
        // Use a type assertion to access the access_token property
        if (response && (response as any).access_token) {
          localStorage.setItem('access_token', (response as any).access_token);
          //console.log(localStorage.getItem('access_token'));
        } else {
          throw new Error('Invalid response');
        }
      }));
      
    return result3;
  }

 
}