import { RolePermission } from './../DTO/RolePermission/RolePermission';
import { Injectable } from '@angular/core';
import { RoleAdd } from '../DTO/RolePermission/Roles';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class RolePermissionService {
  back = this.config.backEnd;

  constructor(private http: HttpClient, private config: ConfigService) {}

  addRole(newRole: RoleAdd) {
    return this.http.post(this.back + '/forum/role/new-role', newRole);
  }

}
