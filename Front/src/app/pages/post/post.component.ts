import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from './../../services/post.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent {
  constructor(
    private userService: UserService,
    private forumService: ForumService,
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
    forum: 0,
    participant: 0,
  };
  
  idForum = Number(this.router.url.split("/")[2])

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
    this.post.forum = this.idForum; 
    console.log(this.post)
    console.log(this.form.value)
    
    this.postService.addPost(this.post).subscribe((res) => {
      this.form.reset();
      this.router.navigate(['forum-home/' + this.idForum]);
      console.log(res);
    });
  }
}
