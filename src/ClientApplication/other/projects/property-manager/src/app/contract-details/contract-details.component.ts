import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { PropertyState } from '../store/property.state';
import { ManagementContractService, ManagementContract } from '@lib/app-core';
import { getContractDetails } from '../store/actions/property.actions';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { selectPropertyState, contractDetails } from '../store/reducers';

@Component({
  selector: 'app-contract-details',
  templateUrl: './contract-details.component.html',
  styleUrls: ['./contract-details.component.scss']
})
export class ContractDetailsComponent implements OnInit {

  id: number;
  detailsForm: FormGroup;;
  contract: ManagementContract;

  contract$ = this.store.pipe(select(contractDetails))
              .subscribe(data => {
                this.contract = data;
              });

  constructor(private actRoute: ActivatedRoute,
              private store: Store<PropertyState>,
              private formBuilder: FormBuilder,
              private router: Router,
              private contractService: ManagementContractService) {
    this.id = this.actRoute.snapshot.params.id;
    console.log(this.id);
   }

  ngOnInit() {

    this.getContractDetails(this.id);

    this.detailsForm = this.formBuilder.group({
      id: [''],
      managementContractTitle: [''],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      placementFeeScale: ['', Validators.required],
      managementFeeScale: ['', Validators.required],
      propertyName: [''],
      managementContractDocUrl: [false],
      managementContractType: [''],
      isActive: [''],
      notes: [''],

      created: [''],
      updated: ['']
    });

    // this.store.pipe(select(contractDetails))
    //           .subscribe(data => {
    //             this.contract = data;
    //             if (data == null){
    //               this.getContractDetails(this.id);
    //             }
    //             else {
    //               this.detailsForm.patchValue(data);
    //             }
    //           });

  }

  getContractDetails(id: number) {
    this.store.dispatch(getContractDetails({payload: id}));
  }

  // getContractDetailsByService (id: number) {
  //   this.contractService.getManagementContractDetails(id)
  //                       .subscribe(data => {
  //                         this.contract = data;
  //                         this.detailsForm.patchValue(data);
  //                       })
  // }


  goBack() {
    this.router.navigate(['/Manage/property/contracts']);
  }

}
