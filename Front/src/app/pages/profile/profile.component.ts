import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { User } from 'src/app/DTO/User/User';
import { ConfigService } from 'src/app/services/config.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  forums: InfoForum[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private config: ConfigService
  ) {}

  authenticated: boolean = true;

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

        this.userService.getForums(this.user).subscribe(list => {
          var newList: InfoForum[] = [];
          list.forEach(element => {
            console.log(element.forumName)
            newList.push({
              id: element.id,
              creator: element.creator,
              forumName: element.forumName,
              descriptionForum: element.descriptionForum
            });
          });

          this.forums = newList;

        });
      },
      error: (error: any) => {
        this.router.navigate(['']);
      }
    });
  }
}
