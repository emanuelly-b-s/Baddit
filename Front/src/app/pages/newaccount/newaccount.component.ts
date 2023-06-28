// import { UserService } from './../services/users.service';
// import { NewAccountService } from './../../services/new-account.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  Validators,
  FormGroup,
  FormBuilder,
} from '@angular/forms';
import { UserService } from '../../services/users.service';
import { User } from '../../interfaces/User';

@Component({
  selector: 'app-newaccount',
  templateUrl: './newaccount.component.html',
  styleUrls: ['./newaccount.component.css'],
})
export class NewaccountComponent {
  constructor(private fb: FormBuilder, private user : UserService) {}

  form : FormGroup  = this.fb.group({
      Email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.minLength(4),
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
        ],
      ],
      UserName: ['', [Validators.required, Validators.minLength(5)]],
      LastName: ['', [Validators.required, Validators.minLength(5)]],
      DateBirth: ['', []],
      NickUser: ['', [Validators.required, Validators.minLength(8)]],
      PasswordUser: ['', [Validators.required, Validators.minLength(8)]],
    });

  userRegister: User = {
    Email: '',
    UserName: '',
    LastName: '',
    DateBirth: new Date(),
    NickUser: '',
    PasswordUser: '',
    saldpassword: '',
    photouser: 5,
  };

  pass : string = "";
  email : string = "";

  passwordChanged(newPass: string) {
    this.pass = newPass;
  }

  emailChanged(newEmail: string) {
    console.log(newEmail)

    this.email = newEmail;
  }


  register() {
    this.userRegister = {...this.form.value};
    this.userRegister.PasswordUser = this.pass;
    this.userRegister.Email = this.email;

    console.log(this.userRegister)

    this.user.add(this.userRegister).subscribe(res =>
      {
        console.log('a');
      });
  }
}
