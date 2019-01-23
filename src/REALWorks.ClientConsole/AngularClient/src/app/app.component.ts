import { Component, ChangeDetectorRef } from '@angular/core';

import { AppMaterialModule } from './app-material/app-material.module';
import { MediaMatcher } from '@angular/cdk/layout';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';
}
