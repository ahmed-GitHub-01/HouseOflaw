import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../_services/auth.service';
import { Injectable, EventEmitter } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}
  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }
    this.toastr.error('يجب تسجل الدخول', 'خطأ', { timeOut: 1500 });
    this.router.navigate(['/login']);
    return false;
  }
}
