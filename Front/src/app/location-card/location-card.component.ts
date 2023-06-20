
import { Component, Input } from '@angular/core';
import { Location } from '../Location';


@Component({
  selector: 'app-location-card',
  templateUrl: './location-card.component.html',
  styleUrls: ['./location-card.component.css']
})
export class LocationCardComponent {
  @Input() location: Location = { name: "", imgPath: ""};
}

