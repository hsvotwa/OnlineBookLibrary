import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { BookSubscription } from '../common-models';

@Injectable({ providedIn: 'root' })

export class BookSubscriptionService {

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
       
    }

  subscribe(bookId) {
    if (localStorage.getItem("user") == null) {
      alert("You are not logged in.");
      this.router.navigate(['/login']);
      return;
    }
    let userId = JSON.parse(localStorage.getItem("user")).Id;
    return this.http.post<BookSubscription>(`${environment.apiUrl}/bookSubscription/subscribe`, { bookId, userId })
          .pipe(map(feedback => {
            alert("Subscribed");
          }));
  }

  unSubscribe(bookId) {
    if (localStorage.getItem("user") == null) {
      alert("You are not logged in.");
      this.router.navigate(['/login']);
      return;
    }
    let userId = JSON.parse(localStorage.getItem("user")).Id;
    return this.http.post<BookSubscription>(`${environment.apiUrl}/bookSubscription/unsubscribe`, { bookId, userId })
      .pipe(map(user => {
        alert("Subscribed");
      }));
  }
}
