import { Directive, ElementRef, AfterViewInit } from '@angular/core';

const BASE_TIMER_DELAY = 10;

@Directive({
  selector: '[appAutofocus]'
})
export class AutofocusDirective implements AfterViewInit {

private focus = true;

  constructor(private el: ElementRef) { }

  ngAfterViewInit(): void {

    const focus = this.el.nativeElement.focus();

    setTimeout(focus, 10);
  }

}
