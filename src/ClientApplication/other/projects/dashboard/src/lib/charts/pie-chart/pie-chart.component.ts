import { Component, OnInit, Input } from '@angular/core';

import { ChartType, ChartOptions } from 'chart.js';
import { Label } from 'ng2-charts';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { DashboardService } from '../../services/dashboard.service';
import { ChartService } from '../../services/chart.service';
import { PieChartData } from '../../models/pie-chart-data.model';

@Component({
  selector: 'lib-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  chartData: PieChartData[];

  // Data = [];
  // Label = [];
  @Input() Data = [];
  @Input() Label = [];
  @Input() Colors = [];

  public pieChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: true,
    legend: {
      position: 'top',
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    }
  };

  public pieChartLabels: Label[] = []; //  = ['In', 'Store', 'Sales'];['Download', 'Sales'], , 'Mail Sales'
  public pieChartData: number[] = []; // [300, 500, 200];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [pluginDataLabels];
  public pieChartColors = [];
  // [
  //   {
  //     backgroundColor: ['rgba(255,0,0,0.7)', 'rgba(0,255,0,0.73)', 'rgba(0,0,255,0.7)'],
  //   },
  // ];

  constructor(private dashboardService: DashboardService,
              private chartService: ChartService) { }

  ngOnInit() {
    this.getPieChartData();
  }


  getPieChartData() {
    // this.chartService.getPieChartData()
    // .subscribe((result: PieChartData[]) => {
    //   // this.chartData = result;
    //   // console.log(this.chartData);
    //   // console.log(result);
    //   result.forEach(x => {
    //     this.Data.push(x.count);
    //     this.Label.push(x.status);
    //   });
    //   console.log(this.Data);
    //   console.log(this.Label);
    //   console.log(this.Colors);
    // });

    this.pieChartData = this.Data;
    this.pieChartLabels = this.Label;
    this.pieChartColors = this.Colors;
  }

}
