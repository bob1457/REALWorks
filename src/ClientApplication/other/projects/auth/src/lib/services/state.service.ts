import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  private currentUrlStore = new BehaviorSubject<any>(null);
  public  currentUrl$: Observable<any> = this.currentUrlStore.asObservable();

  constructor() { }


  setCurrentUrl(url: any) {
    debugger;
    this.currentUrlStore.next(url);
    console.log(url);
  }
  
}
