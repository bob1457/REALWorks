import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { DashState } from '../store/dash.state';
import { getAllTenants } from '../store/dash.actions';
import { BarChartData } from '../models/bar-chart.model';
import { ChartService } from '../services/chart.service';

@Component({
  selector: 'lib-dash-tenant',
  templateUrl: './dash-tenant.component.html',
  styleUrls: ['./dash-tenant.component.css']
})
export class DashTenantComponent implements OnInit {

  breakpoint: number;

  chartData = [];
  chartLabel = [];

  chartData2 = [];
  chartLabel2 = [];  

  constructor(private store: Store<DashState>, private chartService: ChartService) { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
    debugger;
    // return
    this.store.dispatch(getAllTenants());
    this.getChartData();
    this.getChartData2();
  }

  getChartData() {
    debugger;
    this.chartService.getBarChartData()
    .subscribe((result: BarChartData[]) => {
      result.forEach( x => {
        this.chartLabel.push(x.city);
        this.chartData.push(x.count);
      });
      console.log(this.chartData);
      console.log(this.chartLabel);
    });

    // this.pieChartData = this.chartData;
    // this.pieChartLabels = this.chartLabel;
  }

  getChartData2() {
    debugger;
    this.chartService.getBarChartData2()
    .subscribe((result: BarChartData[]) => {
      result.forEach( x => {
        this.chartLabel2.push(x.city);
        this.chartData2.push(x.count);
      });
      console.log(this.chartData2);
      console.log(this.chartLabel2);
    });

    // this.pieChartData = this.chartData;
    // this.pieChartLabels = this.chartLabel;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 1;
  }

}
