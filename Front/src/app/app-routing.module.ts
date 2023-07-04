import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NewaccountComponent } from './pages/new-account/new-account.component';
import { ForumPageComponent } from './pages/forum-page/forum-page.component';
import { ForumRegisterComponent } from './pages/forum-register/forum-register.component';
import { CardsComponent } from './pages/cards/cards.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient


const routes: Routes = [

  { path: '', component: LoginComponent },
  { path: 'home-page', component: HomePageComponent },
  { path: 'new-account', component: NewaccountComponent },
  { path: 'forum-home', component	: ForumPageComponent},
  { path: 'forum-register', component : ForumRegisterComponent },
  { path: 'profile-user', component : ProfileComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
