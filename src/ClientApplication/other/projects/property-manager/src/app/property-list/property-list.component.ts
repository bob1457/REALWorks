import { PropertyState } from './../store/property.state';
import { Property, PropertyService } from '@lib/app-core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Store, select } from '@ngrx/store';
import { getPropertyList, getPropertyDetails, addProperty, updateProperty, updatePropertyStatus, removeProperty } from '../store/actions/property.actions';
import { propertyList} from '../store/reducers/property.reducer';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {

  baseUrl = 'http://localhost:21799';

  propertyId: any = 1;

  list: Property[];
  propertyList$: Observable<Property[]>;
  // tslint:disable-next-line: max-line-length
  displayedColumns: string[] = ['icon', 'id', 'propertyName', 'propertyNumber', 'propertyType1', 'status', 'createdDate', 'updateDate', 'action'];
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private propertyService: PropertyService,
              private store: Store<PropertyState>) { }

  dataSource = new MatTableDataSource<Property>();

  ngOnInit() {
    // this.getPropertyList();
    // this.propertyList$ = 
    // this.store.select(propertyList);
    this.store.dispatch(getPropertyList());
    // this.propertyList$ = 
    
    // debugger;
    this.store.pipe(
      select(propertyList)).subscribe(data => { 
        this.list = data ;
        console.log(data);
        this.dataSource.data = this.list;
        console.log(this.dataSource.data);
      });    
  }

  getPropertyList() {
    debugger;
    return this.propertyService.getPropertyList()
    .subscribe((pList: Property[]) => {
      this.list = pList;
      console.log(this.list);
      this.dataSource.data = pList;
      console.log(this.dataSource.data);
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  GetPropertyDetails(id: any) {
    debugger;
    return this.store.dispatch(getPropertyDetails({payload: id}));
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  AddProperty() { // ppt is the input parameter, ignored in unit testing   ppt: Property

  const property: Property = {
    id: 0,
    propertyName: 'Real Property',
    propertyDesc: 'string',
    propertyType1: '',
    propertyManagerUserName: 'string',
    propertyLogoImgUrl: 'string',
    propertyVideoUrl: 'string',
    propertyBuildYear: 0,
    isActive: true,
    isShared: true,
    status: 0,
    isBasementSuite: true,
    // createdDate: '2019-07-27T19:37:57.799Z',
    // updateDate: '2019-07-27T19:37:57.799Z',
    propertyAddressId: 0,
    propertyFeatureId: 0,
    propertyFacilityId: 0,
    propertyOwnerId: 0,
    propertySuiteNumber: 'string',
    propertyNumber: 'string',
    propertyStreet: 'string',
    propertyCity: 'string',
    propertyStateProvince: 'string',
    propertyCountry: 'string',
    propertyZipPostCode: 'string',
    gpslongitudeValue: 'string',
    gpslatitudeValue: 'string',
    stove: true,
    refrigerator: true,
    dishwasher: true,
    airConditioner: true,
    laundry: true,
    blindsCurtain: true,
    furniture: true,
    tvinternet: true,
    commonFacility: true,
    securitySystem: true,
    utilityIncluded: true,
    fireAlarmSystem: true,
    others: 'string',
    facilityNotes: 'string',
    numberOfBedrooms: 0,
    numberOfBathrooms: 0,
    numberOfLayers: 0,
    numberOfParking: 0,
    basementAvailable: true,
    totalLivingArea: 0,
    featureNotes: 'string',
    userName: 'string',
    firstName: 'string',
    lastName: 'string',
    contactEmail: 'string',
    contactTelephone1: 'string',
    contactTelephone2: 'string',
    onlineAccessEnbaled: true,
    userAvartaImgUrl: 'string',
    roleId: 0,
    notes: 'string',
    ownerStreetNumber: 'string',
    ownerCity: 'string',
    ownerStateProv: 'string',
    ownerZipPostCode: 'string',
    ownerCountry: 'string',
    isSameAddress: true ,
    ownerList: null,
    contractList: null
    // ownerAddress: {},
    // propertyAddress: {},
    // propertyFacility: {
    //   stove: true,
    //   refrigerator: true,
    //   dishwasher: true,
    //   airConditioner: true,
    //   laundry: true,
    //   blindsCurtain: true,
    //   furniture: true,
    //   tvinternet: true,
    //   commonFacility: true,
    //   securitySystem: true,
    //   utilityIncluded: true,
    //   fireAlarmSystem: true,
    //   others: 'string',
    //   notes: 'string'
    // },
    // propertyFeature: {
    //   numberOfBedrooms: 0,
    //   numberOfBathrooms: 0,
    //   numberOfLayers: 0,
    //   numberOfParking: 0,
    //   basementAvailable: true,
    //   totalLivingArea: 0,
    //   isShared: true,
    //   notes: 'string'
    // }
  };

  debugger;
  return this.store.dispatch(addProperty({payload: property}));

}

UpdateProperty() {
  const property: any = {
    propertyId: 1003,
    propertyName: 'Last Update REAL',
    propertyDesc: 'update again!!!',
    type: 0,
    propertyManagerId: 0,
    propertyLogoImgUrl: 'string',
    propertyVideoUrl: 'string',
    propertyBuildYear: 0,
    isActive: true,
    isShared: true,
    furnishingId: 0,
    status: 1,
    isBasementSuite: true,
    propertySuiteNumber: '101',
    propertyNumber: '9876',
    propertyStreet: '102 Street',
    propertyCity: 'Surrey',
    propertyStateProvince: 'string',
    propertyCountry: 'string',
    propertyZipPostCode: 'string',
    stove: true,
    refrigerator: true,
    dishwasher: true,
    airConditioner: true,
    laundry: true,
    blindsCurtain: true,
    furniture: true,
    tvinternet: true,
    commonFacility: false,
    securitySystem: true,
    utilityIncluded: true,
    fireAlarmSystem: true,
    others: 'string',
    facilityNotes: 'string',
    numberOfBedrooms: 3,
    numberOfBathrooms: 0,
    numberOfLayers: 2,
    numberOfParking: 1,
    basementAvailable: true,
    totalLivingArea: 0,
    featureNotes: 'string'
  };
  debugger;
  return this.store.dispatch(updateProperty({payload: property}));
}

UpdatePropertyStatus() {
  const propertyStatus: any = {
    id: 1003,
    status: 2
  };

  debugger;
  return this.store.dispatch(updatePropertyStatus({payload: propertyStatus}));


}

RemoveProperty() {
  const propertyToRemove: any = {
    propertyId: 1002,
    active: false
  };

  debugger;
  return this.store.dispatch(removeProperty({payload: propertyToRemove}));
}







}
