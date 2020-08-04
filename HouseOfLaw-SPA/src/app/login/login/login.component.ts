import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private authServices: AuthService, private router: Router) {}

  ngOnInit(): void {}
  // tslint:disable-next-line: typedef
  login() {
    this.authServices.login(this.model).subscribe(
      (next) => {
        if (localStorage.getItem('token')){
          this.router.navigate(['/home']);
        }else{
          this.router.navigate(['/login']);
        }
      },
      (error) => {
        console.log('فشل فى الدخول');
      }
    );
  }
}
