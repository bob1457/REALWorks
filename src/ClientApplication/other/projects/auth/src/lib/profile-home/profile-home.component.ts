import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { Location } from '@angular/common';
import { User } from '../models';
import { Store, select } from '@ngrx/store';
import * as fromAuth from '../store/auth.state';
import { getUserInfo } from '../store/auth.reducers';

import * as sparkmd5 from 'spark-md5';
import { MatRadioChange, MatRadioButton } from '@angular/material';
import { StateService } from '../services/state.service';

@Component({
  selector: 'lib-profile-home',
  templateUrl: './profile-home.component.html',
  styleUrls: ['./profile-home.component.css']
})
export class ProfileHomeComponent implements OnInit {

  serverUrl = 'http://localhost:58088/';
  url = 'https://localhost:44336/api/Profile/avatar/update';

  user: User;

  rolename = '';
  loading = false;
  uploadMsg = '';
  showMsg = false;


  hash:any = null;
  // email = '';
  gravatar = '';

  gAvatar = true;
  imgUrl:any = null;
  emailHash:any = null;

  public progress: number;
  public message: string;
  @Output() public uploadFinished = new EventEmitter();

  constructor(private location: Location,
              private store: Store<fromAuth.AuthState>,
              private stateService: StateService,
              private httpClient: HttpClient) { }





  ngOnInit() {
    debugger;
    this.store.pipe(select(getUserInfo)).subscribe(userData => {
      if (userData == null) {
        this.user = JSON.parse(localStorage.getItem('auth'));
      } else {
         this.user = userData;
         console.log('user from profile homne: ' + userData);
      }

      switch (this.user.role) {
        case 'pm':
            this.rolename = 'Property Manager';
            break;
        case 'tenant':
            this.rolename = 'Tenant';
            break;
        default:
        break;
      }
    });

    this.hash = sparkmd5.hash(this.user.email);
    this.gravatar = this.createIdenticon(this.hash);

  }



  goBack() {
    this.location.back();
  }

  openInput() {
    document.getElementById('fileInput').click();
  }

  // onChange(event) {
  //   console.log('file uploaded...' + event);
  // }

  public onChange = (files) => {
    debugger;
    this.loading = true;

    if (files.length === 0) {
      return;
    }

    // const fileToUpload = files[0] as File;
    let fileToUpload = <File> files[0];

    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    formData.append('UserName', this.user.username);

    this.httpClient.post(this.url, formData, {reportProgress: true, observe: 'events'})
    .subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if (event.type === HttpEventType.Response) {
        this.message = 'Update success.';
        this.uploadFinished.emit(event.body);
      }
      this.loading = false;
      this.uploadMsg = 'Done';
      this.showMsg = true;
      
      setTimeout(() => {
        this.showMsg = false;        
      }, 2000);

    });

    var fileReader = new FileReader();

    fileReader.readAsDataURL(files[0]);
    fileReader.onload = (_event) => {
      this.imgUrl = fileReader.result;
      this.stateService.setCurrentUrl(this.imgUrl);      
      console.log(this.imgUrl);
      localStorage.setItem('newAvatarUrl', this.imgUrl );
      console.log(localStorage.getItem('newAvatarUrl'));
    }  

  }


  AvatarTypeChange(mrChange: MatRadioChange) {
    console.log(mrChange.value);
    let mrButton: MatRadioButton = mrChange.source;
    

    if (mrChange.value == 2 && mrButton.checked) {
      this.gAvatar = false;
      localStorage.setItem('useGravatar', 'false');

      this.emailHash = sparkmd5.hash(this.user.email);
      if (this.imgUrl == null) {
        // this.imgUrl = 'https://www.gravatar.com/avatar/' + this.emailHash + '?d=identicon'; 
        this.imgUrl = this.serverUrl + '/' + this.user.avatarUrl;
        this.stateService.currentUrl$ = this.imgUrl;
      }           
    }
    else {
      this.gAvatar = true;
    }
    
    console.log(mrButton.checked);
    
 }
 

  createIdenticon(emailHash: any): string {
    return 'https://www.gravatar.com/avatar/' + emailHash + '?d=identicon';
  }

}
