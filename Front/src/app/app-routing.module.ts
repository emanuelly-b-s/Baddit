import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NewaccountComponent } from './newaccount/newaccount.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient
import { AppComponent } from './app.component';

const routes: Routes = [

  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'createnewaccount', component: NewaccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
