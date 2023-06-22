import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewAccount } from 'src/interfaces/NewAccount';

@Injectable({
  providedIn: 'root'
})
export class NewAccountService {



  constructor(private http: HttpClient) { }

  addUser(newAccount: NewAccount)
  {
    return this.http.post(' ')
  }
}
