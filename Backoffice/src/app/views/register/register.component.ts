import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Register } from '../../Models/Register';
import { AuthService } from '../../core/services/_auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'register.component.html'
})
export class RegisterComponent {

  userRegister: Register;

  constructor(private _auth: AuthService, private _router:Router) { }

  registerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    birthday: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl('')
  });

  submitRegistration(){
    this.userRegister = new Register(this.registerForm.value);
    this.register(this.userRegister);
  }

  async register(register: Register){
    await this._auth.register(register);
    this._router.navigateByUrl('/login');
  }

}
