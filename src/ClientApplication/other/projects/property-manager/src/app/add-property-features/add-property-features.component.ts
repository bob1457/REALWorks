import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-property-features',
  templateUrl: './add-property-features.component.html',
  styleUrls: ['./add-property-features.component.scss']
})
export class AddPropertyFeaturesComponent implements OnInit {

  @Input() addForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

}
