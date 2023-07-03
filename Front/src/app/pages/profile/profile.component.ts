import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent {
  constructor(private userService: UserService, private router: Router) {}

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
        console.log(this.user);
      },
      error: (error: any) => {
        console.log(error);
        this.router.navigate(['']);
      },
    });
  }
}
