import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ForumRegister } from '../DTO-front/ForumRegister';
import { ConfigService } from './config.service';
import { User } from '../DTO-front/User';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newForum: ForumRegister, userInfo : User) {
    return this.http.post(this.back + '/new-forum', newForum);
  }

  all()
  {
    // return this.http.get<Forum[]>(this.back + "/forums")
  }
}
