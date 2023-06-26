import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { NewAccount } from '../interfaces/NewAccount';


@Injectable({
  providedIn: 'root'
})
export class UserRegisterService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  register(user: NewAccount, callback: CallableFunction)
  {
    this.http
      .post(this.config.backEnd + '/newUser', user)
      .subscribe((result) =>
      {
        callback(result)
      });
  }
}
