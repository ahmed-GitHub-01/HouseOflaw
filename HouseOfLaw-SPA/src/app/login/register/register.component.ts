import { AuthService } from './../../_services/auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(
    private authService: AuthService,
    private toastr: ToastrService
  ) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {}
  // tslint:disable-next-line: typedef
  cancel() {
    this.cancelRegister.emit(false);
    this.toastr.success('Hello world!', 'Toastr fun!');
  }
  // tslint:disable-next-line: typedef
  register() {
    this.authService.regiSter(this.model).subscribe(
      () => {
        this.toastr.success('Hello world!', 'Toastr fun!');
      },
      (error) => {
        this.toastr.error('Hello world!', 'Toastr fun!');
      }
    );
  }
}
