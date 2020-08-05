import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = 'http://localhost:5000/Auth/';
  constructor(private http: HttpClient) {}
  // tslint:disable-next-line: typedef
  login(model: any) {
    return this.http.post(this.baseUrl + 'perlogin', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }
  // tslint:disable-next-line: typedef
  regiSter(model: any)
  {
    return this.http.post(this.baseUrl + 'paraaregistrey', model);
  }
}
