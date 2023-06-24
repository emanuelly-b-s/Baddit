import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';

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

  constructor(private router: Router) {}
  passwordChanged(event: any) {
    this.password = event;
  }

  login() {
    // Aqui precisariamos fazer essa verificação no banco de dados
    if (this.emailuser == '' && this.password == '123') {
      // Isso evidentemente não é seguro, mas a ideia é bom e será melhorada no futuro
      sessionStorage.setItem(this.emailuser, this.password);
      this.router.navigate(['/homepage']);
    }
  }

  getErrorMessage() {
    return this.email.hasError('required')
      ? 'You must enter a value'
      : this.email.hasError('email')
      ? 'Not a valid email'
      : '';
  }
}
