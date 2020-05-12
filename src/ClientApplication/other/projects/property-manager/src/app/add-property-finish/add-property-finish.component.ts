import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-property-finish',
  templateUrl: './add-property-finish.component.html',
  styleUrls: ['./add-property-finish.component.scss']
})
export class AddPropertyFinishComponent implements OnInit {

  @Input() addForm: FormGroup

  constructor(private location: Location) { }

  ngOnInit() {
  }

  submit(formValue) { // Add validation here...for all fields if any
    debugger;
    console.log(this.addForm);
    console.log(formValue);
    this.location.back();
  }

}
