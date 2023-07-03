import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../DTO/User/User';
import { UserRegister } from '../DTO/User/UserRegister';
import { UserLogin } from '../DTO/User/UserLogin';
import { ConfigService } from './config.service';
import { Jwt } from '../DTO/Jwt';
import { SessionLogin } from '../DTO/SessionLogin';
import { UserSecurityToken } from '../DTO/User/UserSecurityToken';
import { InfoForum } from '../DTO/Forum/InfoForum';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newUser: UserRegister) {
    return this.http.post(this.back + '/user/new-account', newUser);
  }

  login(login: UserLogin) {
    return this.http.post<SessionLogin>(this.back + '/user/login', login);
  }

  validateToken(session: Jwt) {
    return this.http.post<Jwt>(this.back + '/user/tokenValidate', session);
  }

  validateUser() {
    let session = sessionStorage.getItem('jwtSession') ?? '';

    return this.http.post<UserSecurityToken>(
      this.back + '/user/tokenValidate', { valueToken: session }
    );
  }

  getUserLoggedIn(jwtSession: Jwt) {
    console.log(jwtSession);
    return this.http.post<User>(this.back + '/user/userLoggedIn', jwtSession);
  }

  getForums(userData : User)
  {
    return this.http.post<InfoForum[]>(this.back + '/user/getForumsRegister', userData);
  }

}
