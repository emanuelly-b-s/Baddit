import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../DTO-front/User';
import { UserLogin } from '../DTO-front/UserLogin';
import { ConfigService } from './config.service';
import { Jwt } from '../DTO-front/Jwt';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newUser: User) {
    // this.http.post(this.config.backEnd + '/newUser', user);
    return this.http.post(this.back + '/newaccountuser', newUser);
  }

  login(login: UserLogin) {
    return this.http.post<UserLogin>(this.back + '/user/login', login);
  }

  validate(session: Jwt) {
    return this.http.post<Jwt>(this.back + 'user/validateSession', session);
  }

  getUserForLogin(jwtSession: Jwt) {
    return this.http.post<User>(
      this.back + 'user/get',
      jwtSession
    );
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
