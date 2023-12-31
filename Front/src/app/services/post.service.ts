import { InfoForum } from './../DTO/Forum/InfoForum';
import { Post } from './../DTO/Post.ts/Post';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { User } from '../DTO/User/User';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  back = this.config.backEnd;

  addPost(newPost: Post) {
    console.log(newPost)
    return this.http.post(this.back + '/forum/post/new-post', newPost);
  }

  getPostsByForum(forumId: InfoForum) {
    return this.http.post<Post[]>(this.back + '/forum/post/getPostsForum', forumId);
  }

  getAllPostsUser(user: User)
  {
    return this.http.post<Post[]>(this.back + '/forum/post/getPostsUser', user);
  }

  getAllPostsFeed()
  {
    return this.http.get<Post[]>(this.back + '/forum/post/getPostsFeed');
  }

}
