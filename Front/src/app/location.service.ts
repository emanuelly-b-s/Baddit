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
    return this.http.post("$initialCatalog = "FullExample"/location", location)
  }
  
  all()
  {
    return this.http.get<Location[]>("$initialCatalog = "FullExample"/location")
  }
  
  seach(query: string)
  {
    return this.http.get<Location[]>("$initialCatalog = "FullExample"/location?search=" + query)
  }
}

