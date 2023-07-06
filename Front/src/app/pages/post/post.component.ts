import { UpDownService } from 'src/app/services/upDown.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from './../../services/post.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent {
  posts: Post[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private postService: PostService,
    private fb: FormBuilder,
    private upDownService : UpDownService

  ) {}

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

  authenticated: boolean = true;

  post: Post = {
    tittle: '',
    postText: '',
    postDate: new Date(),
    forum: 0,
    participant: 0,
    upvote: 0,
    downvote: 0,
    id: 0
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

  form: FormGroup = this.fb.group({
    tittle: [
      '',
      [Validators.required, Validators.minLength(3), Validators.maxLength(15)],
    ],
    postText: ['', [Validators.required, Validators.minLength(5)]],
  });

  addPost() {
    this.post = { ...this.form.value };
    this.post.participant = this.user.userId;
    this.post.forum = this.forum.id;

    this.postService.addPost(this.post).subscribe((res) => {
      this.form.reset();
      this.router.navigate(['forum-home/' + this.forum.id]);
    });
  }
}
