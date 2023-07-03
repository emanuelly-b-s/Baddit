import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';
import { ListParticipantsForum } from 'src/app/DTO/Forum/ParticipantForum';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.css'],
})
export class ForumPageComponent {
  constructor(
    private userService: UserService,
    private router: Router,
    private forumService: ForumService,
    private fb: FormBuilder
  ) {}

  authenticated: boolean = true;

  user: User = {
    userId: 0,
    username: '',
    nickUser: '',
    email: '',
    photouser: 0,
  };

  forumData: InfoForum = {
    id: 1,
    creator: 0,
    forumName: '',
    descriptionForum: '',
  };

  creator: number = 0;

  participanteForum: ListParticipantsForum = {
    Participant: 0,
    forum: 0,
  };

  addUser() {
    this.participanteForum.Participant = this.creator;
    this.participanteForum.forum = this.forumData.id;

    this.forumService.addUser(this.participanteForum).subscribe((res) =>
    {
      console.log(res);
    })

  }

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;
        this.creator = res.userId;
        console.log(this.user);
      },
      error: (error: any) => {
        this.router.navigate(['']);
      },
    });
  }
}
