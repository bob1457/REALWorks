import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { getPropertyList, getPropertyOwnerList, getContractList } from '../store/dash.actions';
import { DashState } from '../store/dash.state';
import { Store } from '@ngrx/store';

@Component({
  selector: 'lib-dashhome',
  templateUrl: './dashhome.component.html',
  styleUrls: ['./dashhome.component.css']
})
export class DashhomeComponent {

  breakpoint: number;

  /** Based on the screen size, switch from standard to one column per row
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Card 1', cols: 1, rows: 1 },
          { title: 'Card 2', cols: 1, rows: 1 },
          { title: 'Card 3', cols: 1, rows: 1 },
          { title: 'Card 4', cols: 1, rows: 1 }
        ];
      }

      return [
        { title: 'Card 1', cols: 2, rows: 1 },
        { title: 'Card 2', cols: 1, rows: 1 },
        { title: 'Card 3', cols: 1, rows: 2 },
        { title: 'Card 4', cols: 1, rows: 1 }
      ];
    })
  );
*/
  constructor(private store: Store<DashState>) {}

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
    debugger;

    // getPropertyList();
    // getPropertyOwnerList();
    // return this.store.dispatch(getPropertyOwnerList()) ;
    return this.store.dispatch(getContractList()) ;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 1;
  }

  // getPropertyList() {
  //   return this.store.dispatch(getPropertyList()) ;
  // }

  // getPropertyOwnerList() {
  //   return this.store.dispatch(getPropertyOwnerList()) ;
  // }

}
