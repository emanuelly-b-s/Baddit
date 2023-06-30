import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../DTO-front/User';
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

  add(newUser: User) {
    return this.http.post(this.back + '/newaccountuser', newUser);
  }

  login(login: UserLogin) {
    return this.http.post<SessionLogin>(this.back + '/login', login);
  }

  validateToken(session: Jwt) {
    return this.http.post<Jwt>(this.back + 'user/tokenValidate', session);
  }

  validateUser() {
    let session = sessionStorage.getItem('jwtSession') ?? '';

    return this.http.post<UserSecurityToken>(
      this.back + 'user/tokenValidate',
        { Value: session }
    );
  }

  getUserForLogin(jwtSession: Jwt) {
    return this.http.post<User>(this.back + 'user/get', jwtSession);
  }

  // seach(query: string)
  // {
  //   return this.http.get<Location[]>("$http://localhost:5066/location?search=" + query)
  // }
}
