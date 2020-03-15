import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
//import { AutofocusDirective } from './autofocus.directive';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [//AutofocusDirective
  LoaderComponent],
  exports: [
    //AutofocusDirective
  ]
})
export class AppCoreModule { }
