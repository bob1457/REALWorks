import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { DashState } from '../store/dash.state';
import { getPropertyListing } from '../store/dash.actions';
import { ChartService } from '../services/chart.service';
import { PieChartData } from '../models/pie-chart-data.model';

@Component({
  selector: 'lib-dash-listing',
  templateUrl: './dash-listing.component.html',
  styleUrls: ['./dash-listing.component.css']
})
export class DashListingComponent implements OnInit {

  breakpoint: number;

  chartData = [];
  chartLabel = [];
  chartColor = [
    {backgroundColor: ['rgba(255,0,0,0.3)', 'rgba(0,255,0,0.3)', 'rgba(0,0,255,0.3)' ]}
  ];

  mChartData = [];
  mChartLabel = [];
  mChartColor = [
    {backgroundColor: ['rgba(255,0,0,0.6)', 'rgba(0,255,0,0.6)', 'rgba(0,0,255,0.6)' ]}
  ];

  constructor(private store: Store<DashState>,
              private chartService: ChartService) { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
    debugger;
    // return this.store.dispatch(getPropertyOwnerList()) ;
    // return
    this.store.dispatch(getPropertyListing()) ;
    this.getPieChartData();
    this.getMarketingPieChartData();
  }

  getPieChartData() {
    this.chartService.getPieChartData()
    .subscribe((result: PieChartData[]) => {
      // this.chartData = result;
      // console.log(this.chartData);
      // console.log(result);
      result.forEach(x => {
        this.chartData.push(x.count);
        this.chartLabel.push(x.status);
      });
      console.log(this.chartData);
      console.log(this.chartLabel);
    });

    // this.pieChartData = this.Data;
    // this.pieChartLabels = this.Label;
  }

  getMarketingPieChartData() {
    this.chartService.getMarketingPieChartData()
    .subscribe((result: PieChartData[]) => {
      // this.chartData = result;
      // console.log(this.chartData);
      // console.log(result);
      result.forEach(x => {
        this.mChartData.push(x.count);
        this.mChartLabel.push(x.status);
      });
      console.log(this.mChartData);
      console.log(this.mChartLabel);
    });

    // this.pieChartData = this.Data;
    // this.pieChartLabels = this.Label;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 1;
  }

}
