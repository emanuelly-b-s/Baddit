import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { HomePageComponent } from './home-page/home-page.component';
import { UploaderComponent } from './uploader/uploader.component';
import { LocationCardComponent } from './location-card/location-card.component';
import { NewLocationPageComponent } from './new-location-page/new-location-page.component';
import { LocationsPageComponent } from './locations-page/locations-page.component';
import { NewaccountComponent } from './newaccount/newaccount.component';
import { CreatePasswordComponent } from './create-password/create-password.component';
import { PasswordComponent } from './password/password.component';

//material aaaaaaaaaaa

import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient

import {
  FormControl,
  Validators,
  FormGroup,
  FormBuilder,
} from '@angular/forms';

import { NgIf } from '@angular/common';


//router desgraçado
import { RouterModule } from '@angular/router';

import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

@NgModule({
  declarations: [
    HomePageComponent,
    LoginComponent,
    UploaderComponent,
    AppComponent,
    LocationCardComponent,
    NewLocationPageComponent,
    LocationsPageComponent,
    NewaccountComponent,
    CreatePasswordComponent,
    PasswordComponent,
    NavComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule, // Adicionado para poder usar o ngModel
    HttpClientModule, // Added for use HttpClient
    ReactiveFormsModule,
    BrowserAnimationsModule, // Added for use ReactiveForms
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    // FormControl,
    // Validators,
    // FormGroup,
    // FormBuilder,
    RouterModule,

    MatCardModule,
    MatSidenavModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatListModule,
    MatIconModule
  ],
  exports: [],

  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AppModule {}
