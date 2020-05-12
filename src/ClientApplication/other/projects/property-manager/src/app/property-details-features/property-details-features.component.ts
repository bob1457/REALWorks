import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-property-details-features',
  templateUrl: './property-details-features.component.html',
  styleUrls: ['./property-details-features.component.scss']
})
export class PropertyDetailsFeaturesComponent implements OnInit {

  @Input() detailsForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

}
