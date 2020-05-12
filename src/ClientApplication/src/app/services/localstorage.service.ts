import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {

  constructor() { }

  getSavedState(localStorageKey: string): any {
    return JSON.parse(localStorage.getItem(localStorageKey));
  }

  setSavedSteate(state: any, localStorageKey: string) {
    localStorage.setItem(localStorageKey, JSON.stringify(state));
  }

}
