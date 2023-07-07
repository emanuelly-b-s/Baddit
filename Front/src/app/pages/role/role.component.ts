import { RolePermissionService } from '../../services/rolePermission.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/DTO/User/User';
import { UserService } from 'src/app/services/users.service';
import { RoleAdd } from 'src/app/DTO/RolePermission/Roles';
import { Permission } from 'src/app/DTO/RolePermission/Permission';
import { RolePermission } from 'src/app/DTO/RolePermission/RolePermission';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
})
export class RoleComponent {
  permissions: Permission[] = [];

  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private rolePermissionService: RolePermissionService,
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

        this.rolePermissionService.getPermissions().subscribe((list) => {
          var newList: Permission[] = [];
          list.forEach((element) => {
            newList.push({
              permissionName: element.permissionName,
              id: element.id,
            });
          });
          console.log(newList);
          this.permissions = newList;
        });
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
  };

  permissionRole: RolePermission = {
    id: 0,
    idRole: 0,
    idPermission: 0,
  };

  idPermission: number = 0;
  idRole: number = 0;

  GetStats(event: any): void {

    if (event.target.checked) {
      this.idPermission = event.target.value;
    }
    console.log(event.target.value, event.target.checked);
  }

  addRole() {
    this.role = { ...this.form.value };
    this.role.forum = Number(this.router.url.split('/')[2]);

    this.permissionRole.idPermission = this.idPermission;
    this.permissionRole.idRole = 0;

    this.rolePermissionService.addRolePermission(this.permissionRole).subscribe((res) => {
      console.log(res);
    })

    this.rolePermissionService.addRole(this.role).subscribe((res) => {
      console.log(res);
      this.router.navigate(['forum-home/' + this.forumID]);
    });
  }
}
