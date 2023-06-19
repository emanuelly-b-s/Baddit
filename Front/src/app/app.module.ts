import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
// import {MatToolbarModule} from '@angular/material/toolbar';
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



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomePageComponent,
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
 ],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
