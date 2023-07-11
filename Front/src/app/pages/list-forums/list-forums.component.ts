import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { ForumService } from 'src/app/services/forum.service';


@Component({
  selector: 'app-list-forums',
  templateUrl: './list-forums.component.html',
  styleUrls: ['./list-forums.component.css']
})
export class ListForumsComponent {

  forums: InfoForum[] = [];

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

          this.forumService.allForums().subscribe((list) => {
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

