import { User } from './../../interfaces/User';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/users.service';
import { UserLogin } from 'src/app/interfaces/UserLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  emailuser = '';
  hide = true;
  password = '';

  constructor(private router: Router, private userService: UserService) {}

  passwordChanged(pass: string) {
    this.password = pass;
  }

  emailChanged(email: string) {
    this.emailuser = email;
  }

  loginUser : UserLogin = {
    email: '',
    passworduser: ''
  }

  login() {
    this.loginUser.passworduser = this.password;
    this.loginUser.email = this.emailuser;

    this.userService.login(this.loginUser)
      .subscribe(res =>
        {
          this.router.navigate(["/home/user"])
        })

  }

  getErrorMessage() {
    return this.email.hasError('required')
      ? 'You must enter a value'
      : this.email.hasError('email')
      ? 'Not a valid email'
      : '';
  }
}
