import { Component, OnInit } from '@angular/core';
import { fadeAnimation } from '../../animations';
import { NavigationStart, NavigationEnd, NavigationCancel, NavigationError, Router, Event } from '@angular/router';

@Component({
  selector: 'app-authenticated-user',
  templateUrl: './authenticated-user.component.html',
  styleUrls: ['./authenticated-user.component.css'],
 // animations: [fadeAnimation]
})
export class AuthenticatedUserComponent implements OnInit {
  showSpinner = true;
  constructor(private router: Router) {
    /* router.events.subscribe((routerEvent: Event) => {
      this.checkRouterEvent(routerEvent);
    }); */
   }

  ngOnInit() {
  }

  /* checkRouterEvent(routerEvent: Event): void {
    if (routerEvent instanceof NavigationStart) {
      this.showSpinner = true;
    }

    if (routerEvent instanceof NavigationEnd ||
      routerEvent instanceof NavigationCancel ||
      routerEvent instanceof NavigationError) {
      this.showSpinner = false;
    }
  } */
}
