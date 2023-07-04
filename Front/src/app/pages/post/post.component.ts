import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from './../../services/post.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent {
  constructor(
    private userService: UserService,
    private router: Router,
    private postService: PostService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;
      },
    });
  }

  authenticated: boolean = true;

  user: User = {
    userId: 0,
    username: '',
    nickUser: '',
    email: '',
    photouser: 0,
  };

  post: Post = {
    tittle: '',
    postText: '',
    postDate: new Date(),
    forum: 1,
    participant: 0,
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
    this.post.forum = 1; // preciso de um void p/ receber o id forum
    
    this.postService.add(this.post).subscribe((res) => {
      this.router.navigate(['forum-home']);
      console.log(res);
    });
  }
}
