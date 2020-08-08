import { AuthGuard } from './_guards/auth.guard';
import { MyProfileComponent } from './Body/home/my-profile/my-profile.component';

import { RegisterComponent } from './login/register/register.component';
import { LoginComponent } from './login/login/login.component';
import { HomeComponent } from './Body/home/home.component';
import { Routes } from '@angular/router';
export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent , canActivate: [AuthGuard] },
  { path: 'profile', component: MyProfileComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
