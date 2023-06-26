import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { NewAccount } from '../interfaces/NewAccount';
import { User } from '../interfaces/User';


@Injectable({
  providedIn: 'root'
})
export class UserRegisterService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  // register()
  // {
  //   this.http
  //     .post(this.config.backEnd + '/newUser', user)
  //     .subscribe();
  // }
}
