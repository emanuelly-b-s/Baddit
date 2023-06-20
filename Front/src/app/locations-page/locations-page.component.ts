import { Component, OnInit } from '@angular/core';
import { Location } from '../Location';
import { LocationService } from '../location.service';

@Component({
  selector: 'app-locations-page',
  templateUrl: './locations-page.component.html',
  styleUrls: ['./locations-page.component.css']
})
export class LocationsPageComponent implements OnInit {
  locations: Location[] = [];

  constructor (private service: LocationService) {}
  
  ngOnInit(): void {
    this.service.all()
      .subscribe(list =>
      {
        console.log(list)
        var newList: Location[] = []
        list.forEach(element => {
          newList.push({
            name: element.name,
            imgPath: "$initialCatalog = "FullExample"/img/" + element.imgPath
          })
        });
        this.locations = newList
      })
  }
}
