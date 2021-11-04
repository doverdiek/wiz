import { BaseService } from './_base';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../Models/Product';
import { Injectable } from '@angular/core';
import { AuthEndPoints } from '../const';
import { Login } from '../../Models/Login';
import { Auth } from '../../Models/Auth';
import { Register } from '../../Models/Register';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class AuthService extends BaseService {

  authService: string;


  constructor(
    http: HttpClient
  ){
    super(http);
    this.authService = environment.AUTH;
  }

  async login(login: Login) : Promise<Auth>{

    let response = await this.post(AuthEndPoints.LOGIN, this.authService, login).toPromise();
    let UserAuth = response.body as Auth;
    this.setJwtToken(UserAuth.token);
    return UserAuth;
  }

  async register(register: Register) {
    let response = await this.post(AuthEndPoints.REGISTER, this.authService, register).toPromise();
    let UserAuth = response.body as Auth;
    return UserAuth;
  }

  setJwtToken(token: string): void {
    return localStorage.setItem('Token', token);
  }


  getJwtToken(): string{
    return localStorage.getItem('Token')
  }

  isLoggedIn(): boolean{
    var token = localStorage.getItem('Token');
    if(token != null){
      return true;
    }
    else{
      return false
    }
  }


}
