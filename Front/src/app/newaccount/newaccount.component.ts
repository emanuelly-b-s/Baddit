// import { NewAccountService } from './../../services/new-account.service';
import { Component } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-newaccount',
  templateUrl: './newaccount.component.html',
  styleUrls: ['./newaccount.component.css'],
})
export class NewaccountComponent {
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

  paswword = new FormControl('', [
    Validators.required,
    Validators.minLength(8)
  ]);

}
