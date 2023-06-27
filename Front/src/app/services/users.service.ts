// import { NewAccount } from './../interfaces/NewAccount';
// import { HttpClient } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { NewAccount } from '../interfaces/NewAccount';
// import { ConfigService } from './config.service';

// @Injectable({
//   providedIn: 'root',
// })
// export class NewAccountService {
//   constructor(private http: HttpClient, private config: ConfigService) {}

//   addUser(newAccount: NewAccount) {
//     return this.http.post(this.config.backEnd + '/new-user', newAccount);

//   }
// }

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewAccount } from '../interfaces/NewAccount';
import { User } from '../interfaces/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  config: any;

  constructor(private http: HttpClient) { }

  add(newUser: User)
  {
    // this.http.post(this.config.backEnd + '/newUser', user);
    return this.http.post("http://localhost:5066" + '/newaccountuser', newUser);
  }

  // all()
  // {
  //   return this.http.get<Location[]>("$http://localhost:5066/location")
  // }

  // seach(query: string)
  // {
  //   return this.http.get<Location[]>("$http://localhost:5066/location?search=" + query)
  // }
}
