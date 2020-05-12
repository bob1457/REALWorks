import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { PropertyState } from '../store/property.state';
import { getPropertyDetails } from '../store/actions/property.actions';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Property, PropertyService } from '@lib/app-core';
import { propertyDetrails } from '../store/reducers';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.scss']
})
export class PropertyDetailsComponent implements OnInit {

detailsForm: FormGroup;

 property$ = this.store.pipe(select(propertyDetrails))
        .subscribe(data => {
          this.property = data;
          // this.detailsForm.patchValue(data);
          console.log(data);
    })
    ;

  constructor(private store: Store<PropertyState>,
              private router: Router,
              private actRoute: ActivatedRoute,
              private formBuilder: FormBuilder,
              private propertyService: PropertyService) {
                this.id = this.actRoute.snapshot.params.id;
                console.log(this.id);
              }

  propertyId: any = 1;
  id: number;
  // property$: Observable<Property[]>;
  property: Property;
  current = '';
  shared = '';
  basement = '';
  

  // property$: Observable<Property>;

  ownersForProperty: any[] ;



  ngOnInit() {
    // debugger;
    // returnthis.store.dispatch(getPropertyDetails(this.propertyId))
    this.GetPropertyDetails(this.id);

    this.detailsForm = this.formBuilder.group({
      propertyId: ['', Validators.required],
      propertyName: ['', Validators.required],
      propertyDesc: [''],
      propertyType1: ['', Validators.required],

      propertyLogoImgUrl: [''],
      propertyVideoUrl: [''],
      propertyBuildYear: [''],
      isActive: [''],
      isShared: [''],
      status: [''],
      isBasementSuite: [false],

      propertySuiteNumber: [''],
      propertyNumber: ['', Validators.required],
      propertyStreet: ['', Validators.required],
      propertyCity: ['', Validators.required],
      propertyStateProvince: ['', Validators.required],
      propertyCountry: ['', Validators.required],
      propertyZipPostCode: ['', Validators.required],
      gpslongitudeValue: [''],
      gpslatitudeValue: [''],

      stove: [''],
      refrigerator: [''],
      dishwasher: [''],
      airConditioner: [''],
      laundry: [''],
      blindsCurtain: [''],
      furniture: [''],
      tvinternet: [''],
      commonFacility: [''],
      securitySystem: [''],
      utilityIncluded: [''],
      fireAlarmSystem: [''],
      others: [''],
      facilityNotes: [''],

      numberOfBedrooms: ['', Validators.required],
      numberOfBathrooms: ['', Validators.required],
      numberOfLayers: ['', Validators.required],
      numberOfParking: ['', Validators.required],
      basementAvailable: ['', Validators.required],
      totalLivingArea: ['', Validators.required],
      featureNotes: [''],

      creationDate: [''],
      updateDate: [''],
      ownerList: this.formBuilder.group({
        userName: [''],
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        contactEmail: ['', Validators.required],
        contactTelephone1: ['', Validators.required],
        contactTelephone2: [''],
        onlineAccessEnbaled: [false],
        userAvartaImgUrl: [''],

        address: this.formBuilder.group({
          ownerStreetNumber: ['', Validators.required],
          ownerCity: ['', Validators.required],
          ownerStateProv: ['', Validators.required],
          ownerZipPostCode: ['', Validators.required],
          ownerCountry: ['', Validators.required]
        })
      })

    });

    // this.selectPropertyDetails();

    // Then select the state from the store, re-set to the form
    // this.store.pipe(select(propertyDetrails))
    //     .subscribe(data => {
    //       this.property = data;
    //       if (data == null){
    //         this.getPropertyDetailsByService(this.id);
    //       }
    //       else {
    //         this.detailsForm.patchValue(data);
    //       }
    //       console.log(data);
    // });

    // this.current = this.property.propertyType1;
    // console.log(this.current);
    // this.shared = this.property.isShared.toString();
    // this.basement = this.property.isBasementSuite.toString();
    console.log(this.basement);
  }

  GetPropertyDetails(id: any) {
    debugger;
    this.store.dispatch(getPropertyDetails({payload: id}));
    // this.property$ =

    // User store to select the state

    // this.store.pipe(select(propertyDetrails))
    // .subscribe(data => {
    //   this.property = data;
    //   this.detailsForm.patchValue(data);
    //   console.log(data);
    // });


    // User servie directlty the first time when the compowent loads
    // this.propertyService.getPropertyDetails(id)
    //     .subscribe(data => {
    //       this.property = data;
    //       this.detailsForm.patchValue(data);
    // });
  }

  // getPropertyDetailsByService (id: number) {
  //   this.propertyService.getPropertyDetails(id)
  //       .subscribe(data => {
  //         this.property = data;
  //         this.detailsForm.patchValue(data);
  //       });
  // }

  selectPropertyDetails() {
    debugger;
    this.store.pipe(select(propertyDetrails))
    .subscribe(data => {
      this.property = data;
      this.detailsForm.setValue(data);
      console.log(data);
    });
  }

  submit() {

  }

  goBack() {
    this.router.navigate(['/Manage/property/propertylist']);
  }

}
