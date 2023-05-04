export class admin_login {
    username:string ="";
    password:string = "";
    grant_type:string ="password";
  }

  export class token_response {
    access_token:string = "";
    token_type ="bearer";
    expires_in = 3599;
}
  