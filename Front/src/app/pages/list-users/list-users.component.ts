import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { InfoParticipant, RoleParticipant } from 'src/app/DTO/Forum/ParticipantForum';
import { ForumService } from 'src/app/services/forum.service';
import { RolePermissionService } from 'src/app/services/rolePermission.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css'],
})
export class ListUsersComponent implements OnInit {
  constructor(
    private forumService: ForumService,
    private router: Router,
    private roleService: RolePermissionService
  ) {}

  forum: InfoForum = {
    id: 0,
    creator: 0,
    forumName: '',
    descriptionForum: '',
  };
  
  listUser: RoleParticipant[] = [];
  forumId: number = 0;
  userPermissions: number[] = [];

  authenticated: boolean = true;

  ngOnInit(): void {
    this.forum.id = Number(this.router.url.split('/')[2]);
    this.forumService.getForumByID(this.forum).subscribe((res) => {
      this.forum = res;

      this.forumService
        .getUsers(this.forum)
        .subscribe((res) => {
          this.listUser = res;
          console.log(this.listUser);
        });
    });
  }


  hasPermission(permission: number) {
    return this.userPermissions.includes(permission);
  }


}
