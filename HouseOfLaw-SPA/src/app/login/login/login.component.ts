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
        this.router.navigate(['/home']);
      },
      (error) => {
        console.log('فشل فى الدخول');
      }
    );
  }
}
