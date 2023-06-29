import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewAccount } from '../DTO-front/NewAccount';
import { User } from '../DTO-front/User';
import { UserLogin } from '../DTO-front/UserLogin';

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

  login(login: UserLogin)
  {
    return this.http.post<UserLogin>("http://localhost:5062/user/login", login)
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
