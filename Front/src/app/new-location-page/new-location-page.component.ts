import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LocationService } from '../location.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-location-page',
  templateUrl: './new-location-page.component.html',
  styleUrls: ['./new-location-page.component.css']
})
export class NewLocationPageComponent {

  constructor(private service: LocationService, private route: Router) {}

  emailFormControl = new FormControl('', []);
  imageCode = ""
  title = ""

  onImageUpdate(code: any)
  {
    this.imageCode = code;
  }

  add()
  {
    this.service.add({
      name: this.title,
      imgPath: String(this.imageCode)
    })
    .subscribe(result =>
      {
        this.route.navigate(["/"])
      }
    )
  }
}

