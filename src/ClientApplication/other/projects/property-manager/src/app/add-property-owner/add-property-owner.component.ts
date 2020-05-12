import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PropertyOwner } from '@lib/dashboard/lib/models/property-owner.model';

@Component({
  selector: 'app-add-property-owner',
  templateUrl: './add-property-owner.component.html',
  styleUrls: ['./add-property-owner.component.scss']
})
export class AddPropertyOwnerComponent implements OnInit {

  @Input() addForm: FormGroup;
  
// PropertyOwner
  owners: any[] = [
    { value:'1', viewValue: 'Bob Yuan'}
  ];

  ownerOption: string;

  constructor() { }

  ngOnInit() {
    this.ownerOption = 'existing';
  }



}
