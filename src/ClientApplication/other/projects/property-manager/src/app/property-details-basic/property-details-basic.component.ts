import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-property-details-basic',
  templateUrl: './property-details-basic.component.html',
  styleUrls: ['./property-details-basic.component.scss']
})
export class PropertyDetailsBasicComponent implements OnInit {

  @Input() detailsForm: FormGroup;
  
  constructor() { }

  ngOnInit() {
  }

}
