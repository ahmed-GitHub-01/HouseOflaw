import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../_services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(
    public authServices: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}
  // tslint:disable-next-line: typedef
  login() {
    this.authServices.login(this.model).subscribe(
      (next) => {
        this.toastr.success('تم تسجيل الدخول بنجاح', 'تأكيد', { timeOut: 800 });
      },
      (error) => {
        this.toastr.error('خطأ فى المستخدم او الرقم السرى', 'خطأ', {
          timeOut: 1500,
        });
      },
      () => {
        this.router.navigate(['/profile']);
      }
    );
  }
  // tslint:disable-next-line: typedef
  loggedIn() {
    return this.authServices.loggedIn();
  }
}
