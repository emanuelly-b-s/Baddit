import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';


@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.css'],
})
export class ForumPageComponent {
  constructor(private userService: UserService, private router: Router, private forumService : ForumService) {}

  authenticated: boolean = true;

  user: User = {
    id: 0,
    username: '',
    email: '',
    photouser: 0,
  };

  forumData: InfoForum = {
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
      },
      error: (error: any) => {
        console.log(error);
        this.router.navigate(['']);
      },
    });

    
  }
}
