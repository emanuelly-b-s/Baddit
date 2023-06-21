import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './home-page/home-page.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';
import { UploaderComponent } from './uploader/uploader.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { LocationCardComponent } from './location-card/location-card.component';
import { NewLocationPageComponent } from './new-location-page/new-location-page.component';
import { LocationsPageComponent } from './locations-page/locations-page.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import {FormControl, Validators} from '@angular/forms';
import {NgIf} from '@angular/common';
import { NewaccountComponent } from './newaccount/newaccount.component';


@NgModule({
  declarations: [
    LoginComponent,
    HomePageComponent,
    UploaderComponent,
    AppComponent,
    LocationCardComponent,
    NewLocationPageComponent,
    LocationsPageComponent,
    NewaccountComponent,
  ],

  imports: [
    NavComponent,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    FormsModule, // Adicionado para poder usar o ngModel
    HttpClientModule, // Added for use HttpClient
    ReactiveFormsModule,
    BrowserAnimationsModule, // Added for use ReactiveForms
    MatCardModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    NgIf,
  ],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
