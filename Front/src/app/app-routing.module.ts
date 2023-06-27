import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NewaccountComponent } from './pages/newaccount/newaccount.component';
import { HttpClientModule } from '@angular/common/http'; // Added for use HttpClient


const routes: Routes = [

  { path: '', component: NewaccountComponent },
  { path: 'login', component: LoginComponent },
  { path: 'createnewaccount', component: NewaccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
