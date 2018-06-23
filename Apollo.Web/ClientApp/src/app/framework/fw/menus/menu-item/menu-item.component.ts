import { Component, Input, OnInit } from '@angular/core';
import { IMenuItem } from '../../services/menu.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent implements OnInit {
  @Input() item: IMenuItem;

  constructor() { }

  ngOnInit() {
  }

}
