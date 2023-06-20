import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Location } from './Location';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }

  add(location: Location)
  {
    return this.http.post("$http://localhost:5066/location", location)
  }

  all()
  {
    return this.http.get<Location[]>("$http://localhost:5066/location")
  }

  seach(query: string)
  {
    return this.http.get<Location[]>("$http://localhost:5066/location?search=" + query)
  }
}

