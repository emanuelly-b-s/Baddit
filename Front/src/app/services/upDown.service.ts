import { UpDown } from './../DTO/UpvoteDownvote';
import { Post } from './../DTO/Post.ts/Post';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class UpDownService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  addUpDown(upDown: UpDown) {
    return this.http.post(this.back + '/post/upDown/upvotesDownvotes', upDown);
  }

  getUpvote(post: Post) {
    console.log(post)
    return this.http.post<number>(this.back + '/post/upDown/countUpvotesDownvotes', post);
  }
}
