import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
export class AppCoreService<T, ID> {

  endPoint = 'http://localhost:21799';

  constructor(
    protected http: HttpClient,
    protected url: string // will be passed in from child class
  ) { }

  // ************************************************************
    // Generic CRUD operations
    // ************************************************************
    save(t: T): Observable<T>{
      return this.http.post<T>(`${this.endPoint}/${this.url}`, t);
    }

    findOne(id: ID) {
      return this.http.get<T>(`${this.endPoint}/${this.url}/${id}`);
    }

    findAll() {
      return this.http.get<T[]>(`${this.endPoint}/${this.url}`);
    }

    update(t: T) {
      return this.http.post<T>(`${this.endPoint}/${this.url}`, t);
    }

    delete(id: ID) {
      return this.http.delete<T>(`${this.endPoint}/${this.url}/${id}`);
    }
}
