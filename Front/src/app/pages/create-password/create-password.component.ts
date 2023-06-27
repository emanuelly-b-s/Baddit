// import { Component, OnChanges, SimpleChanges } from '@angular/core';
// import { FormControl, Validators } from '@angular/forms';

// @Component({
//   selector: 'app-create-password',
//   templateUrl: './create-password.component.html',
//   styleUrls: ['./create-password.component.css'],
// })
// export class CreatePasswordComponent {

//   protected password = new FormControl('', [
//     Validators.required,
//     Validators.pattern(
//       "(?=^.{8,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"
//     )
//   ]);

//   getErrorMessage() {
//     return this.password.hasError('required')
//       ? 'You must enter a password'
//       : this.password.hasError('pattern')
//       ? 'Not a valid password'
//       : '';
//   }
// }

import { Component, OnChanges, SimpleChanges } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-create-password',
  templateUrl: './create-password.component.html',
  styleUrls: ['./create-password.component.css'],
})
export class CreatePasswordComponent {

  password = '';
  passwordsMatching = '' ;
  match = true;

  protected matchPassword()
  {
    this.match = this.passwordsMatching === this.password;
  }

  protected passwordChanged(event: any) {
    this.password = event;
    this.matchPassword();
  }

}
