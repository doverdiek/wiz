import { Component } from '@angular/core';
import { AuthService } from '../../core/services/_auth';
import { Auth } from '../../Models/Auth';
import { Login } from '../../Models/Login';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})

export class LoginComponent {

  userLogin: Login;

  constructor(private _auth: AuthService, private _router: Router){
  }

  ngOnInit() : void{
    this.userLoginForm.reset();
  }

  userLoginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  async login(login: Login){
    await this._auth.login(login);
    this._router.navigateByUrl('/dashboard');

  }

  submitLogin(){
    this.userLogin = new Login(this.userLoginForm.value);
    this.login(this.userLogin);
  }

}
