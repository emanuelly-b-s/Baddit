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
    console.log(upDown)
    return this.http.post(this.back + '/post/upDown/upvotesDownvotes', upDown);
  }
}
