import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ForumRegister } from '../DTO/Forum/ForumRegister';
import { ConfigService } from './config.service';
import { User } from '../DTO/User/User';
import { InfoForum } from '../DTO/Forum/InfoForum';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newForum: ForumRegister) {
    return this.http.post(this.back + 'user/new-forum', newForum);
  }

  getForumByID(idForum: number)
  {
    console.log(idForum);
    return this.http.post<InfoForum>(this.back + 'user/get-forum', idForum);
  }

}
