import { Injectable } from '@angular/core';
import { RoleAdd } from '../DTO/Roles';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class RoleService {

  back = this.config.backEnd;

  constructor(private http: HttpClient, private config: ConfigService) {}
  add(newRole: RoleAdd) {
    return this.http.post(this.back + '/forum/role/new-role', newRole);
  }
}
