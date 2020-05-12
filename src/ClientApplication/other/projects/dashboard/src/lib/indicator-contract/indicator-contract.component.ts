import { ManagementContract } from '@lib/app-core';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'lib-indicator-contract',
  templateUrl: './indicator-contract.component.html',
  styleUrls: ['./indicator-contract.component.css']
})
export class IndicatorContractComponent implements OnInit {

  @Input() contractList: ManagementContract[];

  constructor() { }

  ngOnInit() {
  }

}
