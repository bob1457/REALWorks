import * as fromAuth from '@lib/auth';
import { Store, select } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { MediaObserver, MediaChange } from '@angular/flex-layout';
import { Router } from '@angular/router';
import { Observable, Subscription, from } from 'rxjs';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { getUserInfo, User } from '@lib/auth';
// import {  } from '@lib/auth';

import * as sparkmd5 from 'spark-md5';

import { PropertyList, ContractList, TenantList, RentalList, OwnerList, MarketingList, RentalAppList } from '@lib/dashboard';
import { StateService } from 'projects/auth/src/public-api';


@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss'],
  animations: [
    trigger('changeSideBarSize', [
      state(
        'decrease',
        style({
          width: '64px',
          transform: 'translateX(-80%)'
        })
      ),
      state(
        'increase',
        style({
          width: '280px',
          transform: 'translateX(0%)'
        })
      ),
      transition('decrease => increase', animate('2000ms')),
      transition('increase => decrease', animate('2000ms'))
    ])
  ]
})
export class SideNavComponent implements OnInit {
  serverUrl = 'http://localhost:58088/';

  currentState = 'increase';

  isAdmin = true;
  n = 13;

  link = '';

  property: any[] = [];
  owners: any[] = [];
  contracts: any[] = [];

  mode = 'side';
  opened = true;

  media$: Observable<MediaChange>;

  watcher: Subscription;
  activeMediaQuery = '';

  ToggleButtonDisplay = 'none';
  SideToggleButtonDisplay = '';

  OpenButtonDisplay = 'none';
  visible = false;
  sidenavWidth = 17.5; // side nav width when started (default: full-width side nav)

  // user: Observable<string>; // this must be a local variable, NOT an Observable
  user: User;
  avatar = '';
  avatar$: Observable<string>;

  hash:any = null;  
  gravatar = '';
  imgUrl:any = null;
  gAvatar = true;

  // theme$ = 'dark-theme'; // this is default -- selecting theme can be implemented using observable from rxjs... later.
  theme$ = 'light-theme';
  // theme$ = 'dark-theme';

  role = '';

  constructor(
    public mediaObserver: MediaObserver,
    private router: Router,
    private stateService: StateService,
    private store: Store<fromAuth.AuthState>
  ) {
    this.watcher = mediaObserver.media$.subscribe(
      (mediaChange: MediaChange) => {
        this.mode = this.getMode(mediaChange);
        this.opened = this.getOpened(mediaChange);
        this.OpenButtonDisplay = this.showHideOpenButton(mediaChange);
      }
    );
  }

  newUrl$ = this.stateService.currentUrl$
      .subscribe(data => {
        this.gAvatar = false;
        this.imgUrl = data;
        this.imgUrl = localStorage.getItem('newAvatarUrl');
        console.log(this.imgUrl);
  })

  ngOnInit() {
    debugger;
    this.store.pipe(select(getUserInfo)).subscribe(userData => { // this.user = userData;
      // this.user = JSON.parse(localStorage.getItem('auth'));
      // localStorage.setItem('auth', JSON.stringify(userData));

      

      console.log(userData);
      if (userData == null) {
        this.user = JSON.parse(localStorage.getItem('auth'));
        this.role = this.user.role;
        console.log(this.user);
      } else {
        this.user = userData;
        localStorage.setItem('auth', JSON.stringify(userData));
        this.role = userData.role;
      }

    });
    
    this.store.pipe(select(PropertyList)).subscribe(data => {
        this.property = data;
      });

    this.store.pipe(select(OwnerList)).subscribe(data => {
        this.owners = data;
      });

    this.store.pipe(select(ContractList)).subscribe(data => {
        this.contracts = data;
      });
      
    // select single state then use async pipe in template for sub/unsub using *ngIf which returns a boolean value // console.log(userData);
    // this.avatar$ = this.store.select(ustate => ustate.user.avatarUrl);
    this.avatar = JSON.parse(localStorage.getItem('avatar'));

    this.hash = sparkmd5.hash(this.user.email);
    this.gravatar = this.createIdenticon(this.hash);

    // Update avatar when upload new custom image
    this.stateService.currentUrl$    
      .subscribe(data => {
        this.gAvatar = false;
        console.log(this.gAvatar);
        this.imgUrl = data;
        this.imgUrl = localStorage.getItem('newAvatarUrl');
        console.log(this.imgUrl);
    })


  }

  showSearch() {
    this.visible = !this.visible;
    // this.searcheElement.nativeElement.focus();
    // this.inputEl.nativeElement.focus();
  }

  onBlurMethod() {
    this.visible = false;
  }

  increase() {
    this.sidenavWidth = 17.5;
    this.SideToggleButtonDisplay = '';
    // console.log('increase sidenav width');
  }
  decrease() {
    this.sidenavWidth = 4;
    // console.log('decrease sidenav width');
  }

  changeSideNav() {
    if (this.sidenavWidth === 17.5) {
      this.sidenavWidth = 4; // mini side nav
      this.ToggleButtonDisplay = 'none';
      this.SideToggleButtonDisplay = 'none';
    } else {
      this.sidenavWidth = 17.5; // full width side nav
      this.ToggleButtonDisplay = 'none';
      this.SideToggleButtonDisplay = '';
    }
    // console.log('side nav width changed to ' + this.sidenavWidth);
  }

  private getMode(mediaChange: MediaChange): string {
    // set mode based on a breakpoint
    if (this.mediaObserver.isActive('gt-sm')) {
      return 'side';
    } else {
      return 'over';
    }
  }

  private showHideOpenButton(mediaChange: MediaChange): string {
    if (this.mediaObserver.isActive('gt-sm')) {
      return 'none'; // hidden
    } else {
      return ''; // show
    }
  }

  private getOpened(mediaChange: MediaChange): any {
    if (this.mediaObserver.isActive('gt-sm')) {
      return 'true';
    } else {
      // this.show_logo = true;
      return 'false';
    }
  }

  changeDark() {
    this.theme$ = 'dark-theme';
  }

  changeLight() {
    this.theme$ = 'light-theme';
  }

  logout(): void {
    // localStorage.clear();

    this.store.dispatch(new fromAuth.LogOut());

    // localStorage.removeItem('currentUser');
    // this.router.navigate(['/']);
    // console.log('logged out!');
  }

  showInfo(link: any) {}

  GetList(){
    this.router.navigateByUrl('/Manage/property/propertylist');
    console.log('going to load list...');
  }

  createIdenticon(emailHash: any): string {
    return 'https://www.gravatar.com/avatar/' + emailHash + '?d=identicon';
  }
}
