import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-property-facilities',
  templateUrl: './add-property-facilities.component.html',
  styleUrls: ['./add-property-facilities.component.scss']
})
export class AddPropertyFacilitiesComponent implements OnInit {

  @Input() addForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

}
