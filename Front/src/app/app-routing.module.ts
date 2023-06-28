import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NewaccountComponent } from './pages/newaccount/newaccount.component';
import { ForumPageComponent } from './pages/forum-page/forum-page.component';
import { ForumRegisterComponent } from './pages/forum-register/forum-register.component';
import { CardsComponent } from './pages/cards/cards.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient


const routes: Routes = [

  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'createnewaccount', component: NewaccountComponent },
  { path: 'forum-home', component	: ForumPageComponent},
  { path : 'forum-register', component : ForumRegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
