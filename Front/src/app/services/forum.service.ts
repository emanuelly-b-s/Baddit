import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Forum } from '../DTO-front/Forum';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newForum: Forum) {
    return this.http.post(this.back + '/new-forum', newForum);
  }

  all()
  {
    return this.http.get<Forum[]>(this.back + "/forums")
  }
}
