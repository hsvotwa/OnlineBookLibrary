import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-book-data',
  templateUrl: './book-data.component.html'
})
export class BookDataComponent {
  public books: Book[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Book[]>(baseUrl + 'api/books').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
}

interface Book {
  title: string;
  yearPublished: number;
  subscriptionPrice: number;
  coverImage: string;
  author: string;
  booked: boolean;
}
