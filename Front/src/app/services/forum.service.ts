import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ForumRegister } from '../DTO/Forum/ForumRegister';
import { ConfigService } from './config.service';
import { User } from '../DTO/User/User';
import { InfoForum } from '../DTO/Forum/InfoForum';
import { InfoParticipant, ListParticipantsForum } from '../DTO/Forum/ParticipantForum';
import { RoleParticipant } from '../DTO/Forum/ParticipantForum';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newForum: ForumRegister) {
    return this.http.post(this.back + '/forum/new-forum', newForum);
  }

  // getForumByID(idForum: number)
  // {
  //   return this.http.get<InfoForum>(this.back + '/forum/get-forum' + idForum);
  // }

  getForumByID(forumData: InfoForum) {
    return this.http.post<InfoForum>(
      this.back + '/forum/get-forum',
      forumData
    );
  }

  addUser(data: ListParticipantsForum) {
    return this.http.post(this.back + '/forum/addUser', data);
  }

  removeUser(data: ListParticipantsForum) {
    return this.http.post(this.back + '/forum/removeUser', data);
  }

  allForums() {
    return this.http.get<InfoForum[]>(this.back + '/forum/searchForum');
  }

  searchForum(forumSearch: string) {
    return this.http.post<InfoForum[]>(
      this.back + '/forum/searchForum',
      forumSearch
    );
  }

  getUsers(forum: InfoForum) {
    return this.http.post<RoleParticipant[]>(
      this.back + '/forum/getAllMembers',
      forum
    );
  }
}
