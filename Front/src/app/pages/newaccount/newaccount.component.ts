// import { UserService } from './../services/users.service';
// import { NewAccountService } from './../../services/new-account.service';
import { Component, EventEmitter, Output } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { UserService } from '../../services/users.service';
import { User } from '../../interfaces/User';


@Component({
  selector: 'app-newaccount',
  templateUrl: './newaccount.component.html',
  styleUrls: ['./newaccount.component.css'],
})
export class NewaccountComponent {

  constructor() { }

  email = new FormControl('', [
    Validators.required,
    Validators.email,
    Validators.minLength(4),
    Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
  ]);

  username = new FormControl('', [
    Validators.required,
    Validators.minLength(5),
  ]);

  password = new FormControl('', [
    Validators.required,
    Validators.minLength(8)
  ]);

  registerUser(user: User)
  {
    userRegister : user =
    {
      email : "",
      username : "",
      lastname : "",
      datebirth : new Date(),
      nickuser : "",
      passworduser : "",
      saldpassword: "",
      photouser : ""
    }
  }
}