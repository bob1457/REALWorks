import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PieChartData } from '../models/pie-chart-data.model';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

  baseUrl = 'http://localhost:21799';

  constructor(private http: HttpClient) { }

  // Property Management Pie Chart Data
  getPieChartData() {
    return this.http.get<PieChartData[]>(`${this.baseUrl}/Charts/piechart`);
  }

  getMarketingPieChartData() {
    return this.http.get<PieChartData[]>(`${this.baseUrl}/Charts/marketing/piechart`);
  }

  getBarChartData() {
    return this.http.get(`${this.baseUrl}/Charts/marketing/barchart`);
  }

  getBarChartData2() {
    return this.http.get(`${this.baseUrl}/Charts/marketing/barchart2`);
  }
}
