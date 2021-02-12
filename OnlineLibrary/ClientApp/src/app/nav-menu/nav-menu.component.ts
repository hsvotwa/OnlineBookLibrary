import { Component, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public user: object;
  public isUserLoggedIn: boolean;
  public userName: string;

  constructor(private router: Router, private cdr: ChangeDetectorRef) {
    if (localStorage.getItem("user") == null) {
      this.isUserLoggedIn = false;
      this.user = null;
      this.userName = "";
      return;
    }
    this.isUserLoggedIn = true;
    this.user = JSON.parse(localStorage.getItem("user"));
    this.userName = JSON.parse(localStorage.getItem("user")).fullName;
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    localStorage.removeItem('user');
    this.isUserLoggedIn = false;
    this.router.navigate(['/login']);
    this.cdr.detectChanges();
  }

  login() {
    localStorage.removeItem('user');
    this.isUserLoggedIn = false;
    this.router.navigate(['/login']);
    this.cdr.detectChanges();
  }
}
