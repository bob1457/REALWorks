import { Component, OnInit } from '@angular/core';

/*export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
}*/

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {
  
  breakpoint: number;

  constructor() { }


  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 6;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 6;
  }

}


// Note, the code that gets the data from server in this file will be moved to its parent component so that this component will be reusable.
