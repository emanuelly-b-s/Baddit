import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  upload(file : File, callback : CallableFunction)
  {
    const formData = new FormData();
    formData.append('file', file, file.name);

    this.http
      .post(this.config.backEnd + '/img', formData)
      .subscribe((result) => {
        callback(result)
      });
  }

  getPath(id : number)
  {
    return this.config.backEnd + '/img/' + id
  }
}
