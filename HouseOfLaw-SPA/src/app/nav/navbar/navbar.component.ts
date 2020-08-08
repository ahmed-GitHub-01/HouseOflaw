import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  username = localStorage.getItem('user');
  constructor(private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {}
  // tslint:disable-next-line: typedef
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
    this.username = 'Other';
    this.toastr.info('تم تسجيل الخروج بنجاح', 'تأكيد', { timeOut: 1500 });
  }
}
