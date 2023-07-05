import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { User } from 'src/app/DTO/User/User';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent {
  posts: Post[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private postService: PostService,
    private fb: FormBuilder
  ) {}

  authenticated: boolean = true;

  post: Post = {
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

  forum: InfoForum = {
    id: 0,
    creator: 0,
    forumName: '',
    descriptionForum: '',
  };

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;

        this.forum.id = Number(this.router.url.split('/')[2]);
        this.postService.getPostsByForum(this.forum).subscribe((list) => {
          var newList: Post[] = [];
          list.forEach((element) => {
            newList.push({
              tittle: element.tittle,
              postText: element.postText,
              postDate: element.postDate,
              forum: element.forum,
              participant: element.participant,
              upvote: element.upvote,
              downvote: element.downvote
            });
          });
          console.log(newList)
          this.posts = newList;
        });
      },
    });
  }
}
