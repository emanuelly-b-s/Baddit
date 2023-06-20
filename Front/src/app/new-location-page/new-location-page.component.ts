import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LocationService } from '../location.service';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { UploaderComponent } from '../uploader/uploader.component';

@Component({
  selector: 'app-new-location-page',
  templateUrl: './new-location-page.component.html',
  styleUrls: ['./new-location-page.component.css'],
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    UploaderComponent
  ],
})
export class NewLocationPageComponent {
  constructor(private service: LocationService, private route: Router) {}

  emailFormControl = new FormControl('', []);
  imageCode = '';
  title = '';

  onImageUpdate(code: any) {
    this.imageCode = code;
  }

  add() {
    this.service
      .add({
        name: this.title,
        imgPath: String(this.imageCode),
      })
      .subscribe((result) => {
        this.route.navigate(['/']);
      });
  }
}
