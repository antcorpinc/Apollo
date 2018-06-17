import { Injectable } from '@angular/core';
import { FrameworkConfigService, IFrameworkConfigSettings } from '../../../framework/fw/services/framework-config.service';

@Injectable({
  providedIn: 'root'
})
export class FrameworkConfigDataService {

  constructor(private frameworkConfigService: FrameworkConfigService) {

   }

    configure() {
      // Todo: Get this data from the http service.
    const config: IFrameworkConfigSettings = {
      socialIcons: [
        { imageFile: 'assets/social-fb-bw.png', alt: 'Facebook', link: 'http://www.facebook.com'},
        { imageFile: 'assets/social-google-bw.png', alt: 'Google +', link: 'http://www.google.com' },
        { imageFile: 'assets/social-twitter-bw.png', alt: 'Twitter', link: 'http://www.twitter.com' }
      ],

      showUserControls: true,
      showStatusBar: true,
      showStatusBarBreakpoint: 0
    };
    this.frameworkConfigService.configure(config);
    }

}
