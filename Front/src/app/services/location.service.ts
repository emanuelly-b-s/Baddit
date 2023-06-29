import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Location } from '../DTO-front/Location';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient, private config : ConfigService) { }

  back = this.config.backEnd;

  add(location: Location)
  {
    return this.http.post(this.back + "/location", location)
  }

  all()
  {
    return this.http.get<Location[]>(this.back + "/location")
  }

  seach(query: string)
  {
    return this.http.get<Location[]>(this.back + "/location?search=" + query)
  }
}

