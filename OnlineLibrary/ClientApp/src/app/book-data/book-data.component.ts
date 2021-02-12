import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../common-models';
import { BookSubscriptionService } from '../common-services';

@Component({
  selector: 'app-book-data',
  templateUrl: './book-data.component.html'
})
export class BookDataComponent {
  public books: Book[];
  public isUserLoggedIn: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private bookSubscriptionService: BookSubscriptionService) {
    http.get<Book[]>(baseUrl + 'api/books').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
    this.isUserLoggedIn = localStorage.getItem("user") != null;
  }

  subscribe(bookId) {
    this.bookSubscriptionService.subscribe(bookId);
  }

  unSubscribe(bookId) {
    this.bookSubscriptionService.unSubscribe(bookId);
  }
}
