import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-property-details-facilities',
  templateUrl: './property-details-facilities.component.html',
  styleUrls: ['./property-details-facilities.component.scss']
})
export class PropertyDetailsFacilitiesComponent implements OnInit {

  @Input() detailsForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

}
