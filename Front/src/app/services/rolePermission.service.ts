import { RolePermission } from './../DTO/RolePermission/RolePermission';
import { Injectable } from '@angular/core';
import { RoleAdd } from '../DTO/RolePermission/Roles';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { Permission } from '../DTO/RolePermission/Permission';

@Injectable({
  providedIn: 'root',
})
export class RolePermissionService {
  back = this.config.backEnd;

  constructor(private http: HttpClient, private config: ConfigService) {}

  addRole(newRole: RoleAdd) {
    return this.http.post(this.back + '/forum/role/new-role', newRole);
  }

  addPermission(newPermission: Permission) {
    return this.http.post(
      this.back + '/forum/role/permission/new-permission',
      newPermission
    );
  }

  getPermissions() {
    return this.http.get<Permission[]>(
      this.back + '/forum/role/permission/get-permissions'
    );
  }

  addRolePermission(newPermissionForRole: RolePermission){
    return this.http.post(
      this.back + '/forum/role/permission/new-permissionRole',
      newPermissionForRole
    );
  }
}
