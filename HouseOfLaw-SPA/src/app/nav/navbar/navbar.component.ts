import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {  }
  // tslint:disable-next-line: typedef
  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
  }
