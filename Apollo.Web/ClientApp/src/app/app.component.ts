import { Component } from '@angular/core';
import { FrameworkConfigDataService } from './common/shared/services/framework-config-data.service';
import { MenuDataService } from './common/shared/services/menu-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private frameworkConfigDataService: FrameworkConfigDataService,
  private menuDataService: MenuDataService) {
    this.initialize();
  }

  initialize() {
    // Initialize the framework settings
    this.frameworkConfigDataService.configure();
    // Initialize the User Profile

    // Intialize Menus -- Todo this is for testing only
    this.menuDataService.initialize();
  }
}
