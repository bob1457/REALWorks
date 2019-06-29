import { AutofocusDirective } from './../../../app-core/autofocus.directive';
import { Component, OnInit, ElementRef, ViewChild, AfterViewInit, Input } from '@angular/core';
import { ObservableMedia, MediaChange } from '@angular/flex-layout';
import { BrowserModule} from '@angular/platform-browser';
import { Router } from '@angular/router';
import { UserService } from '../../../account/services/user.service';


@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit, AfterViewInit {

  mode: string = 'side';
  opened: boolean = true;

  visible: boolean = false;
  show_logo: boolean = false;

  ToggleButtonDisplay: string = 'none';

  OpenButtonDisplay: string = 'none';

  sidenavWidth = 17.5; // side nav width when started (default: full-width side nav)

  serverUrl = 'http://localhost:58088/';
  //imgUrl = 'Images/Avatars/default.png';

  user: any;
  isAdmin = false;

  constructor(private media: ObservableMedia, private router: Router, private userService: UserService) {
    this.media.subscribe((mediaChange: MediaChange) => {
      this.mode = this.getMode(mediaChange);
      this.opened = this.getOpened(mediaChange);
      this.OpenButtonDisplay = this.showHideOpenButton(mediaChange,);
    });
  }


  // @ViewChild('search') searcheElement: ElementRef;

  showSearch() {
    this.visible = !this.visible;
    // this.searcheElement.nativeElement.focus();
    // this.inputEl.nativeElement.focus();
  }

  onBlurMethod() {
    this.visible = false;
  }

  private getMode(mediaChange: MediaChange): string {
    // set mode based on a breakpoint
    if (this.media.isActive('gt-sm')) {
      return 'side';
    } else {
      return 'over';
    }
  }

  private showHideOpenButton(mediaChange: MediaChange): string {
    if (this.media.isActive('gt-sm')) {
      return 'none'; // hidden
    } else {
      return ''; // show
    }
  }

  private getOpened(mediaChange: MediaChange): any {
    if (this.media.isActive('gt-sm')) {
      return 'true';
    } else {
      // this.show_logo = true;
      return 'false';
    }
  }

  ngOnInit() {
    let username: string = localStorage.getItem('username');
    // console.log('user name is: ' + localStorage.getItem('username'));

    debugger;
    /**/
    this.userService.getUserProfile(username).subscribe(data => {
      this.user = data;
      if (this.user.userRole === 'admin') {
        this.isAdmin = true;
      }
      console.log(this.user);
    });

  }

  ngAfterViewInit() {
    // console.log('inputEl is ${this.inputEl.nativeElement}');
  }

  increase() {
    this.sidenavWidth = 17.5;
    console.log('increase sidenav width');
  }
  decrease(){
    this.sidenavWidth = 4;
    console.log('decrease sidenav width');
  }

  changeSideNav() {

    if (this.sidenavWidth === 17.5) {
      this.sidenavWidth = 4; // mini side nav
      // this.ToggleButtonDisplay = '';
    } else {
      this.sidenavWidth = 17.5; // full width side nav
      // this.ToggleButtonDisplay = 'none';
    }
    console.log('side nav width changed to ' + this.sidenavWidth);
  }

  logout() {
    localStorage.clear();
    //localStorage.removeItem('currentUser');
    this.router.navigate(['/']);
    console.log('Logged out!');
  }

}
