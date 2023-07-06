import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NavComponent } from './pages/nav/nav.component';
import { LoginComponent } from './pages/login/login.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UploaderComponent } from './pages/uploader/uploader.component';
import { LocationCardComponent } from './pages/location-card/location-card.component';
import { NewLocationPageComponent } from './pages/new-location-page/new-location-page.component';
import { LocationsPageComponent } from './pages/locations-page/locations-page.component';
import { NewaccountComponent } from './pages/new-account/new-account.component';
import { CreatePasswordComponent } from './pages/create-password/create-password.component';
import { PasswordComponent } from './pages/password/password.component';
import { EmailComponent } from './pages/email/email.component';
import { SideNavHomePagComponent } from './pages/side-nav-home-pag/side-nav-home-pag.component';

//router desgraçado
import { RouterModule } from '@angular/router';
import { ForumPageComponent } from './pages/forum-page/forum-page.component';
import { CardsComponent } from './pages/cards/cards.component';
import { PostComponent } from './pages/post/post.component';
import { SideNavComponent } from './pages/side-nav/side-nav.component';



import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient

import { NgIf } from '@angular/common';
import { ForumRegisterComponent } from './pages/forum-register/forum-register.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RoleComponent } from './pages/role/role.component';
import { CardComponent } from './card/card.component';




@NgModule({
  declarations: [
    PostComponent,
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
    NavComponent,
    EmailComponent,
    ForumPageComponent,
    CardsComponent,
    SideNavComponent,
    ForumRegisterComponent,
    ProfileComponent,
    SideNavComponent,
    SideNavHomePagComponent,
    RoleComponent,
    CardComponent

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
  bootstrap: [AppComponent]

})
export class AppModule {}
