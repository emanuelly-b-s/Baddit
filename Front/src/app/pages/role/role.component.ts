import { RoleService } from './../../services/role.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { RoleAdd } from 'src/app/DTO/Roles';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
})
export class RoleComponent {
  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private roleService: RoleService,
    private router: Router
  ) {}

  authenticated: boolean = true;

  form: FormGroup = this.fb.group({
    roleName: ['', Validators.required],
    newPost: [''],
    newRole: [''],
    deletPost: [''],
  });

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;

        this.forumID = Number(this.router.url.split('/')[2]);
      },
    });
  }

  forumID: number = 0;

  user: User = {
    userId: 0,
    username: '',
    nickUser: '',
    email: '',
    photouser: 0,
  };

  role: RoleAdd = {
    roleName: '',
    forum: 0,
  };

  addRole() {
    this.role = { ...this.form.value };
    this.role.forum = Number(this.router.url.split('/')[2]);
    console.log(this.forumID)

    console.log(this.role)

    this.roleService.add(this.role).subscribe((res) => {
      console.log(res);
      this.router.navigate(['forum-home/' + this.forumID]);
    });
  }
}
