import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScreenService {

  private resizeSource = new Subject<null>();
  resize$ = this.resizeSource.asObservable();

    // The below are pixel values of the screen.
  largeBreakpoint = 800;
  screenWidth = 1000;
  screenHeight = 800;

  constructor() {

      try {
          this.screenWidth = window.innerWidth;
          this.screenHeight = window.innerHeight;
          window.addEventListener('resize', (event) => this.onResize(event));
      }  catch (e) {
          // we're going with default screen dimensions of screenwidth and screenheight as
          // defined above
      }
  }
  isLarge(): boolean {
      return this.screenWidth >= this.largeBreakpoint;
  }
  isBelowLarge(): boolean {
    return this.screenWidth < this.largeBreakpoint;
  }

  onResize($event): void {
      this.screenWidth = window.innerWidth;
      this.screenHeight = window.innerHeight;
      // Notify any subscribers that the screen has been resized so act accordingly.
      this.resizeSource.next();
  }
}
