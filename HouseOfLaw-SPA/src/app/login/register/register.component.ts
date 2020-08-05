import { AuthService } from './../../_services/auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(private authService: AuthService) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {}
  // tslint:disable-next-line: typedef
  cancel() {
    this.cancelRegister.emit(false);
    console.log('Canceled');
  }
  // tslint:disable-next-line: typedef
  register() {
    this.authService.regiSter(this.model).subscribe(
      () => {
        console.log('seccess');
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
