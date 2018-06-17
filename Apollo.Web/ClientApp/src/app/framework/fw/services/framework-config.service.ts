import { Injectable } from '@angular/core';

// These are for the top bae menus for social icons.
export interface IIconFiles {
  imageFile: string;
  alt: string;
  link: string;
}

export interface IFrameworkConfigSettings {
  showUserControls?: boolean;
  showStatusBar?: boolean;
  showStatusBarBreakpoint?: number;
  socialIcons?: Array<IIconFiles>;
}

@Injectable({
  providedIn: 'root'
})
export class FrameworkConfigService {
  showUserControls?: boolean;
  showStatusBar?: boolean;
  showStatusBarBreakpoint?: number;
  socialIcons?: Array<IIconFiles>;

  constructor() { }

  configure(settings: IFrameworkConfigSettings): void {
    Object.assign(this, settings);
}

}
