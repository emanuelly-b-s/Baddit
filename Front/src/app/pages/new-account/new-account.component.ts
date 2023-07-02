import { Component } from '@angular/core';
import {
  Validators,
  FormGroup,
  FormBuilder,
} from '@angular/forms';
import { UserService } from '../../services/users.service';
import { UserRegister } from '../../DTO/User/UserRegister';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newaccount',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css'],
})
export class NewaccountComponent {
  constructor(private fb: FormBuilder, private user : UserService, private router: Router) {}

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

  userRegister: UserRegister = {
    Email: '',
    UserName: '',
    LastName: '',
    DateBirth: new Date(),
    NickUser: '',
    PasswordUser: '',
    photouser: 5,
  };

  pass : string = "";
  email : string = "";
  photouser: number = 0;

  passwordChanged(newPass: string) {
    this.pass = newPass;
  };

  // photoChanged(newPhoto: number) {
  //   this.photouser = newPhoto;
  // }

  emailChanged(newEmail: string) {
    this.email = newEmail;
  };

  register() {
    this.userRegister = {...this.form.value};
    this.userRegister.PasswordUser = this.pass;
    this.userRegister.Email = this.email;

    this.user.add(this.userRegister).subscribe(res =>
      {
        this.router.navigate(['']);
      });
  }
}
