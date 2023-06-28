import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Forum } from '../DTO-front/Forum';

@Injectable({
  providedIn: 'root'
})
export class ForumService {

  constructor(private http: HttpClient) { }

  add(newForum: Forum)
  {
    return this.http.post("http://localhost:5066" + '/new-forum', newForum);
  }

}
