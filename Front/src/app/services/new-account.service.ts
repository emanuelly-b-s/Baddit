import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewAccount } from '../interfaces/NewAccount';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class NewAccountService {
  constructor(private http: HttpClient, private config: ConfigService) {}

  addUser(newAccount: NewAccount) {
    const formData = new FormData();
    formData.append()

    this.http
      .post(this.config.backEnd)

    return this.http.post(' ');
  }
}
