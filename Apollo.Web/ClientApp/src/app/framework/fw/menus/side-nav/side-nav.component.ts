import { Component, OnInit, ElementRef, AfterViewInit, ViewChild } from '@angular/core';
import { ScreenService } from '../../services/screen.service';
import { MenuService } from '../../services/menu.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit , AfterViewInit {

  @ViewChild('appDrawer') appDrawer: ElementRef;
  constructor(public menuService: MenuService, public screenService: ScreenService) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    this.menuService.appDrawer = this.appDrawer;
  }

}
