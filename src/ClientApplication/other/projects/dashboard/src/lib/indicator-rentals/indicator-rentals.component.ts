import { Component, OnInit, Input } from '@angular/core';
import { PropertyLease } from '@lib/app-core';

@Component({
  selector: 'lib-indicator-rentals',
  templateUrl: './indicator-rentals.component.html',
  styleUrls: ['./indicator-rentals.component.css']
})
export class IndicatorRentalsComponent implements OnInit {

  @Input() rentalList: PropertyLease[];

  constructor() { }

  ngOnInit() {
  }

}
