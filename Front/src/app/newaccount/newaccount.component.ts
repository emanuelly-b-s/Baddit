// import { UserService } from './../services/users.service';
// import { NewAccountService } from './../../services/new-account.service';
import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { UserRegisterService } from '../services/user-register.service';
import { User } from '../interfaces/User';
import { UserService } from '../services/users.service';

@Component({
  selector: 'app-newaccount',
  templateUrl: './newaccount.component.html',
  styleUrls: ['./newaccount.component.css'],
})
export class NewaccountComponent {
  constructor(@Inject(UserService) private userService: UserService) {}


  addUser = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.minLength(4),
      Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
    ]),
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
    ]),
    lastname: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
    ]),
    datebirth: new FormControl('', []),
    nickusername: new FormControl('', []),
    passworduser: new FormControl('', []),
    // saldpassword: new FormControl('', [])
  });

    dadosUser : User = 
  
 

  register()
  {
    this.userService.add(this.addUser).subscribe(()  => {});
  }
}

  // saveUser() {
  //   this.user = this.addUserForm.value;
  //   this.userService.saveUser(this.user).subscribe((response: any) => {
  //     console.log(response);
  //   });
  // }

  // email = new FormControl('', [
  //   Validators.required,
  //   Validators.email,
  //   Validators.minLength(4),
  //   Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
  // ]);

  // username = new FormControl('', [
  //   Validators.required,
  //   Validators.minLength(5),
  // ]);

  // password = new FormControl('', [
  //   Validators.required,
  //   Validators.minLength(8)
  // ]);

  // userRegister : User =
  // {
  //   email : "",
  //   username : "",
  //   lastname : "",
  //   datebirth : new Date(),
  //   nickuser : "",
  //   passworduser : "",
  //   saldpassword: "",
  //   photouser : ""
  // }

  // registerUser()
  // {
  //  this.userService.register();
  // }
}

// @Output() public onUploadFinished = new EventEmitter<any>();

// constructor(private service: UserRegister) {}
// ngOnInit() {}

// registerUser(us: any)
// {
//   if (files.length === 0)
//     return;

//   let fileToUpload = <File>files[0];
//   this.service.upload(fileToUpload, (result : any) =>
//   {
//     this.onUploadFinished.emit(result)
//   })
// }
