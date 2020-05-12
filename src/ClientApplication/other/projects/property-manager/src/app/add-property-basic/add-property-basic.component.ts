import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-property-basic',
  templateUrl: './add-property-basic.component.html',
  styleUrls: ['./add-property-basic.component.scss']
})
export class AddPropertyBasicComponent implements OnInit {

  @Input() addForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

}
