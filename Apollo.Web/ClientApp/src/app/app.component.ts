import { Component } from '@angular/core';
import { FrameworkConfigDataService } from './common/shared/services/framework-config-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private frameworkConfigDataService: FrameworkConfigDataService) {
    this.initialize();
  }

  initialize() {
    // Initialize the framework settings
    this.frameworkConfigDataService.configure();
    // Initialize the User Profile
  }
}
