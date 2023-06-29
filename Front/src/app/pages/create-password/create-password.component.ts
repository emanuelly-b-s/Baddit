import { EventEmitter } from '@angular/core';
import { Component, OnChanges, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-create-password',
  templateUrl: './create-password.component.html',
  styleUrls: ['./create-password.component.css'],
})
export class CreatePasswordComponent {

  password = '';
  passwordsMatching = '' ;
  match = true;

  @Output() onPasswordChanged = new EventEmitter<string>();

  protected matchPassword()
  {
    this.match = this.passwordsMatching === this.password;
  }

  protected passwordChanged(event: any) {
    this.password = event;
    this.matchPassword();
    this.onPasswordChanged.emit(this.password)
  }

}
