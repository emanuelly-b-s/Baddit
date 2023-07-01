import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../DTO-front/User';
import { UserRegister } from '../DTO-front/UserRegister';
import { UserLogin } from '../DTO-front/UserLogin';
import { ConfigService } from './config.service';
import { Jwt } from '../DTO-front/Jwt';
import { SessionLogin } from '../DTO-front/SessionLogin';
import { UserSecurityToken } from '../DTO-front/UserSecurityToken';

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
      this.back + '/user/tokenValidate',
        { Value: session }
    );
  }

  getUserLoggedIn(jwtSession: Jwt) {
    console.log(jwtSession);  
    return this.http.post<User>(this.back + '/user/userLoggedIn', jwtSession);
  }

}
