import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css'],
})
export class EmailComponent {
  @Output() onEmailChanged = new EventEmitter<string>();

  email = new FormControl('', [Validators.required, Validators.email]);

  emailA = '';

  protected emailChanged(event: any) {
    this.email = event;
    this.onEmailChanged.emit(this.emailA);
  }

  getErrorMessage() {
    return this.email.hasError('required')
      ? 'You must enter a value'
      : this.email.hasError('email')
      ? 'Not a valid email'
      : '';
  }
}
