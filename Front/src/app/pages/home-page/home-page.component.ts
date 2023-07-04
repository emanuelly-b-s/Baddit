import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { ListParticipantsForum } from 'src/app/DTO/Forum/ParticipantForum';
import { User } from 'src/app/DTO/User/User';
import { ForumService } from 'src/app/services/forum.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit, OnDestroy {
  forums: InfoForum[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private ForumService: ForumService,
    private route: ActivatedRoute
  ) {}

  authenticated: boolean = true;

  user: User = {
    userId: 0,
    username: '',
    email: '',
    photouser: 0,
    nickUser: '',
  };

  forum: InfoForum =
  {
    id: 0,
    creator: 0,
    forumName: '',
    descriptionForum: ''
  }

  ngOnInit(): void {

      let jwt = sessionStorage.getItem('jwtSession') ?? '';

      this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
        next: (res: User) => {
          this.user = res;

          this.userService.getForums(this.user).subscribe((list) => {
            console.log(list);
            var newList: InfoForum[] = [];
            list.forEach((element) => {
              newList.push({
                forumName: element.forumName,
                id: element.id,
                creator: element.creator,
                descriptionForum: element.descriptionForum,
              });
            });
            this.forums = newList;
          });
        },
      });
    }
    ngOnDestroy(): void {
      throw new Error('Method not implemented.');
    }
}
