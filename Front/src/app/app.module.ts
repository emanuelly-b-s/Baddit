import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HomePageComponent } from './home-page/home-page.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient
import { ReactiveFormsModule } from '@angular/forms'; // Added for use ReactiveForms
import {Component} from '@angular/core';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import { UploaderComponent } from './uploader/uploader.component';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomePageComponent,
    UploaderComponent
  ],

  imports: [
    NavComponent,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    FormsModule, // Adicionado para poder usar o ngModel
    HttpClientModule, // Added for use HttpClient
    ReactiveFormsModule, BrowserAnimationsModule,// Added for use ReactiveForms
    MatCardModule,
    UploaderComponent

 ],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
