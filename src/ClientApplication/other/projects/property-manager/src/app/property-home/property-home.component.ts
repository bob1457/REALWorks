import { PropertyState } from './../store/property.state';
import { Subscription } from 'rxjs';
import { PropertyService, Property } from '@lib/app-core';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { getPropertyList } from '../store/actions/property.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-property-home',
  templateUrl: './property-home.component.html',
  styleUrls: ['./property-home.component.scss']
})
export class PropertyHomeComponent implements OnInit {

  constructor(private propertyService: PropertyService,
              private store: Store<PropertyState>,
              private router: Router) { }

  list: Property[];
  serverUri = 'http://localhost:19807/';

  ngOnInit() {
    debugger;
    // return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    // return 
    this.store.dispatch(getPropertyList())  ;
    // propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    // this.router.navigateByUrl('/Manage/property/propertylist');
    console.log(this.router.url); 
  }

  // MOVED to property-list component
  // getPropertyList() {
  //   debugger;
  //   return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; });
  // }

}
