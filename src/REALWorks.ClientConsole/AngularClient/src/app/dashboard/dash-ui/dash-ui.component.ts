import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dash-ui',
  templateUrl: './dash-ui.component.html',
  styleUrls: ['./dash-ui.component.scss']
})
export class DashUiComponent implements OnInit {

  breakpoint: number;

 /* cards = [
    { title: 'Card 1', cols: 2, rows: 1, content: 'indicator' },
    { title: 'Card 2', cols: 1, rows: 2,  content: 'property' },
    { title: 'Card 3', cols: 1, rows: 1,  content: 'tenant' },
    { title: 'Card 4', cols: 1, rows: 1, content: 'others' }
  ];
*/
  constructor() { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 1;
  }

}
