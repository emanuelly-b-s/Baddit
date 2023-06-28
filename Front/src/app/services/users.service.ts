import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewAccount } from '../interfaces/NewAccount';
import { User } from '../interfaces/User';
import { UserLogin } from '../interfaces/UserLogin';

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

  login(loginUser : UserLogin)
  {
    return this.http.get("$http://localhost:5066/" + '/login', loginUser);
  }

  // getUserForum(idUser : number, idForum : number)
  // {
        // return this.http.get<>
  // }

  // seach(query: string)
  // {
  //   return this.http.get<Location[]>("$http://localhost:5066/location?search=" + query)
  // }
}
