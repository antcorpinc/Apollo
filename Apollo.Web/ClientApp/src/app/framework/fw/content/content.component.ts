import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MenuService } from '../services/menu.service';
import { ScreenService } from '../services/screen.service';
import {slideInAnimation } from '../../../common/animations';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError, Event } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css'],
  animations: [slideInAnimation]
})
export class ContentComponent implements OnInit {

  showSpinner = true;

  constructor(public menuService: MenuService,
    public screenService: ScreenService, private router: Router, private cd: ChangeDetectorRef) {

      router.events.subscribe((routerEvent: Event) => {
        this.checkRouterEvent(routerEvent);

      });
    }

  ngOnInit() {
  }
  checkRouterEvent(routerEvent: Event): void {
    if (routerEvent instanceof NavigationStart) {
      this.showSpinner = true;
      this.cd.detectChanges();
    }

    if (routerEvent instanceof NavigationEnd ||
      routerEvent instanceof NavigationCancel ||
      routerEvent instanceof NavigationError) {
      this.showSpinner = false;
    }

  }
}
