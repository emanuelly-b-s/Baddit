import { User } from './../../DTO-front/User';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { UserService } from 'src/app/services/users.service';
import { UserLogin } from 'src/app/DTO-front/UserLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  hide = true;

  constructor(
    private router: Router,
    private userService: UserService
  ) {}


  loginUser: UserLogin = {
    email: '',
    passworduser: '',
  };

  pass : string = "";
  email : string = "";

  passwordChanged(newPass: string) {
    this.pass = newPass;
  }

  emailChanged(newEmail: string) {
    this.email = newEmail;
  }

  returnLogin: boolean = false;


  login() {
//     this.loginUser.passworduser = this.pass;
//     this.loginUser.email = this.email;

//     console.log(this.loginUser)

//     this.userService.login(this.loginUser).subscribe(res =>
//       {
//         if (!res.sucess) {
//           this.returnLogin = true;
//         }
//       })

//   }

//   if (!res.success) {
//     this.loginFailure = true;
//     return;
// }

// sessionStorage.setItem('jwtSession', res.jwt);
// this.router.navigate(['/home']);
// });
}

  // getErrorMessage() {
  //   return this.form.Email.hasError('required')
  //     ? 'You must enter a value'
  //     : this.email.hasError('email')
  //     ? 'Not a valid email'
  //     : '';
  // }
}
