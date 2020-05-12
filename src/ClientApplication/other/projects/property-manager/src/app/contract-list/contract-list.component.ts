import { ManagementContract } from '@lib/app-core';
import { ManagementContractService } from './../../../../app-core/src/lib/property/services/management-contract.service';
import { PropertyState } from './../store/property.state';
import { Component, OnInit, ViewChild } from '@angular/core';
import { getContractList, getContractDetails, addManagementContract, updateContract } from '../store/actions/property.actions';
import { contractList } from '../store/reducers/property.reducer';
import { Store, select } from '@ngrx/store';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-contract-list',
  templateUrl: './contract-list.component.html',
  styleUrls: ['./contract-list.component.scss']
})
export class ContractListComponent implements OnInit {

  list: ManagementContract[];
  contractList$: Observable<ManagementContract[]>;

  displayedColumns: string[] = ['icon', 'id', 'managementContractTitle', 'propertyName', 'managementContractType', 'startDate', 'endDate', 'contractSignDate',  'action'];

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private store: Store<PropertyState>,
              private contractService: ManagementContractService) { }

  dataSource = new MatTableDataSource<ManagementContract>();

  ngOnInit() {
    debugger;
    this.store.dispatch(getContractList());
    this.getContractList();
    // this.contractList$ = this.store.select(contractList);
  }

  getContractList() {
    // this.contractService.getManagementContractList()
    //   .subscribe(clist => {
    //     this.dataSource.data = clist;
    //     console.log(this.dataSource.data);
    // })
    debugger;
    this.store.pipe(select(contractList))
    .subscribe(data => {
      this.list = data;
      this.dataSource.data = this.list;
    })
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  getContractDetails(id: number) {
    this.store.dispatch(getContractDetails({payload: id}));
  }

  addContract() {
    const contract: ManagementContract = {
      id: 0,
      ManagementContractTitle: 'New contract',
      StartDate: '2019-08-01T19:50:09.124Z',
      EndDate: '2020-08-31T19:50:09.124Z',
      PlacementFeeScale: '199%',
      ManagementFeeScale: '10%',
      ContractSignDate: '2019-08-23T19:50:09.124Z',
      PropertyId: 1,
      ManagementContractDocUrl: '',
      ManagementContractType: 1,
      IsActive: true,
      Notes: 'just a new management contract'
    };

    debugger;

    return this.store.dispatch(addManagementContract({payload: contract}));
  }

  updateContract() {
    const contract: any = {
      id: 1,
      ManagementContractTitle: 'Newly Updated contract',
      StartDate: '2019-09-15T19:50:09.124Z',
      EndDate: '2020-10-15T19:50:09.124Z',
      PlacementFeeScale: '100%',
      ManagementFeeScale: '10%',
      // ContractSignDate: '2019-08-23T19:50:09.124Z',
      // PropertyId: 1,
      // ManagementContractDocUrl: '',
      // ManagementContractType: 1,
      // IsActive: true,
      Notes: 'just a updated management contract'
    };

    debugger;

    return this.store.dispatch(updateContract({payload: contract}));

  }

}
