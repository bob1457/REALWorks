import { Property } from '@lib/app-core';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'lib-indicator-property',
  templateUrl: './indicator-property.component.html',
  styleUrls: ['./indicator-property.component.css']
})
export class IndicatorPropertyComponent implements OnInit {

  @Input() propertyList: Property[];

  constructor() { }

  ngOnInit() {
  }

}
