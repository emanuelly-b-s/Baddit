import { RolePermissionService } from '../../services/rolePermission.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { RoleAdd } from 'src/app/DTO/RolePermission/Roles';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
})
export class RoleComponent {
  permissionsList: number[] = [];

  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private rolePermissionService: RolePermissionService,
    private router: Router
  ) {}

  authenticated: boolean = true;

  form: FormGroup = this.fb.group({
    roleName: ['', Validators.required],
  });

  addPost: boolean = false;
  deletePost: boolean = false;
  editPost: boolean = false;
  manageRole: boolean = false;
  dropUser: boolean = false;
  dropForum: boolean = false;

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
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
    id: 0,
    roleName: '',
    forum: 0,
    permissions: [],
  }

  onInputChange(event: any, check: boolean) {
    let value: number = event.target.value;
    console.log(event.target.checked)
    console.log(value);

    if (event.target.checked) this.permissionsList.push(value);
    else
      this.permissionsList = this.permissionsList.filter(
        (d: number) => d !== value
      );
  }

  addRole() {
    this.role = { ...this.form.value };
    this.role.forum = Number(this.router.url.split('/')[2]);
    this.role.permissions = this.permissionsList;
    console.log(this.permissionsList);

    this.rolePermissionService.addRole(this.role).subscribe((res) => {
      console.log(res);
      this.router.navigate(['forum-home/' + this.forumID]);
    });
  }
}
