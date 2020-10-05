import { AuthGuard } from './_guards/auth.guard';
import { MyProfileComponent } from './Body/home/my-profile/my-profile.component';

import { RegisterComponent } from './login/register/register.component';
import { LoginComponent } from './login/login/login.component';
import { HomeComponent } from './Body/home/home.component';
import { Routes } from '@angular/router';
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'register', component: RegisterComponent },
      { path: 'profile', component: MyProfileComponent },
    ],
  },
  { path: '', redirectTo: '', pathMatch: 'full' },
];
