import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';
import { ListParticipantsForum } from 'src/app/DTO/Forum/ParticipantForum';

@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.css'],
})
export class ForumPageComponent implements OnInit {
  subscription: any;

  constructor(
    private userService: UserService,
    private router: Router,
    private forumService: ForumService,
    private route: ActivatedRoute
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
    id: 0,
    creator: 0,
    forumName: '',
    descriptionForum: '',
  };

  creator: number = 0;

  participanteForum: ListParticipantsForum = {
    Participant: 0,
    forum: 0,
  };

  listParticipant: ListParticipantsForum = {
    forum: 0,
    Participant: 0
  };

  followForum() {
    this.listParticipant.forum =  Number(this.router.url.split('/')[2]);
    this.listParticipant.Participant = this.user.userId;

    this.forumService.addUser(this.listParticipant).subscribe((res: any) => {
      console.log(res);
    });
  }

  addUser() {
    this.participanteForum.Participant = this.creator;
    this.participanteForum.forum = this.forumData.id;

    this.forumService.addUser(this.participanteForum).subscribe((res) => {
      console.log(res);
    });
  }

  removeUser() {
    this.participanteForum.Participant = this.creator;
    this.participanteForum.forum = this.forumData.id;

    this.forumService.removeUser(this.participanteForum).subscribe((res) => {
    });
  }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe((params) => {
      this.forumData.id = params['id'];
    });

    let jwt = sessionStorage.getItem('jwtSession') ?? '';
    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;
        this.creator = res.userId;
      },

      error: (error: any) => {
        this.router.navigate(['']);
      },
    });

        this.forumService.getForumByID(this.forumData).subscribe((res) => {
          this.forumData = res;
          
        });
  }

  // ngOnDestroy(): void {
  //   throw new Error('Method not implemented.');
  // }
}
