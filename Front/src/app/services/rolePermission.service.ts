import { RolePermission } from './../DTO/RolePermission/RolePermission';
import { Injectable } from '@angular/core';
import { RoleAdd } from '../DTO/RolePermission/Roles';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { InfoForum } from '../DTO/Forum/InfoForum';

@Injectable({
  providedIn: 'root',
})
export class RolePermissionService {
  back = this.config.backEnd;

  constructor(private http: HttpClient, private config: ConfigService) {}

  addRole(newRole: RoleAdd) {
    console.log(newRole);
    return this.http.post(this.back + '/forum/role/new-role', newRole);
  }

  permissions(forum: InfoForum) {
    return this.http.post<number[]>(this.back + '/forum/role/new-role', forum);
  }
}
