import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ForumRegister } from '../DTO/Forum/ForumRegister';
import { ConfigService } from './config.service';
import { User } from '../DTO/User/User';
import { InfoForum } from '../DTO/Forum/InfoForum';
import { ParticipantForum } from '../DTO/Forum/ParticipantForum';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newForum: ForumRegister) {
    return this.http.post(this.back + '/forum/new-forum', newForum);
  }

  getForumByID(idForum: number)
  {
    console.log(idForum);
    return this.http.post<InfoForum>(this.back + '/forum/get-forum', idForum);
  }

  addUser(data : ParticipantForum)
  {
    console.log(data);
    return this.http.post(this.back + '/forum/addUser', data);
  }

}
