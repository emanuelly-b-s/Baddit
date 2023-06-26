import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css'],
})
export class EmailComponent {
  email = new FormControl('', [
    Validators.required, 
    Validators.email]);

    getErrorMessage() {
      return this.email.hasError('required')
        ? 'You must enter a value'
        : this.email.hasError('email')
        ? 'Not a valid email'
        : '';
    }
}
