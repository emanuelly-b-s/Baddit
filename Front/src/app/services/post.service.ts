import { Post } from './../DTO/Post.ts/Post';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  add(newPost: Post) {
    return this.http.post(this.back + '/forum/post/new-post', newPost);
  }
}