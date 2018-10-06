import { Component, OnInit, Input } from '@angular/core';
import { IMenuItem, MenuService } from '../../services/menu.service';
import { ScreenService } from '../../services/screen.service';
import { Router } from '@angular/router';
import { trigger, state, transition, animate, style } from '@angular/animations';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-side-nav-item',
  templateUrl: './side-nav-item.component.html',
  styleUrls: ['./side-nav-item.component.css'],
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({transform: 'rotate(0deg)'})),
      state('expanded', style({transform: 'rotate(180deg)'})),
      transition('expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
      ),
    ])
  ]
})
export class SideNavItemComponent implements OnInit {
  expanded: boolean;
  @Input() depth: number;
  @Input() item: IMenuItem;
  constructor(public menuService: MenuService , public screenService: ScreenService,
    public router: Router) {
    if (this.depth === undefined) {
      this.depth = 0;
    }
   }

  ngOnInit() {
  }

  onItemSelected(item: IMenuItem) {
    if (!item.submenu || !item.submenu.length) {
      this.router.navigate([item.route]);
      this.menuService.showingLeftSideMenu = false;
      this.menuService.closeNav();
    }
    if (item.submenu && item.submenu.length) {
      this.expanded = !this.expanded;
    }
  }

}
