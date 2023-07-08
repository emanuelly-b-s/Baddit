import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { User } from 'src/app/DTO/User/User';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-cards-feed',
  templateUrl: './cards-feed.component.html',
  styleUrls: ['./cards-feed.component.css']
})
export class CardsFeedComponent {
  posts: Post[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private postService: PostService,
  ) {}

  authenticated: boolean = true;

  post: Post = {
    id: 0,
    tittle: '',
    postText: '',
    postDate: new Date(),
    forum: 0,
    participant: 0,
    upvote: 0,
    downvote: 0
  };

  user: User = {
    userId: 0,
    username: '',
    nickUser: '',
    email: '',
    photouser: 0,
  };

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;


        this.postService.getAllPostsFeed().subscribe((list) => {
          var newList: Post[] = [];
          list.forEach((element) => {
            console.log(element);
            newList.push({
              id: element.id,
              tittle: element.tittle,
              postText: element.postText,
              postDate: element.postDate,
              forum: element.forum,
              participant: element.participant,
              upvote: element.upvote,
              downvote: element.downvote
            });
          });
          this.posts = newList;
        });
      },
    });
  }

}
