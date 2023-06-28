import { Component, OnInit } from '@angular/core';
import { Location } from '../../DTO-front/Location';
import { LocationService } from '../../services/location.service';
import { ConfigService } from '../../services/config.service';


@Component({
  selector: 'app-locations-page',
  templateUrl: './locations-page.component.html',
  styleUrls: ['./locations-page.component.css']
})
export class LocationsPageComponent implements OnInit {
  locations: Location[] = [];

  constructor (private service: LocationService, private config : ConfigService) {}

  ngOnInit(): void {
    this.service.all()
      .subscribe(list =>
      {
        console.log(list)
        var newList: Location[] = []
        list.forEach(element => {
          newList.push({
            name: element.name,
            imgPath: this.config.backEnd + "/img/" + element.imgPath
          })
        });
        this.locations = newList
      })
  }
}
