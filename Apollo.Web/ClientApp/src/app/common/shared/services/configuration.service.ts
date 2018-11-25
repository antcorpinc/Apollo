import { Injectable, Inject } from '@angular/core';
import { AppSettingsViewModel } from '../../viewmodels/appsettingsviewmodel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

    // Endpoint of the Server Controller for AppSettings ie AppSettingsController
  private readonly configUrlPath: string = 'AppSettings';
  private configData: AppSettingsViewModel;
  constructor(private http: HttpClient ) {

 }
  // Call the AppSettings  endpoint, deserialize the response,
 // and store it in this.configData

 loadConfigurationData(): Promise<AppSettingsViewModel> {
   console.log('From window directy:' + window.location.host);

  // return this.http.get(`${this.originUrl}${this.configUrlPath}`)
  // Todo : Need to change the Http or Https w/o hardocding
  console.log('Location: is ' + window.location.protocol);
 // return this.http.get(`http://${window.location.host}/${this.configUrlPath}`)
 return this.http.get(`${window.location.protocol}//${window.location.host}/${this.configUrlPath}`)
    .toPromise()
    .then((response: any) => {
      this.configData = response;
      return this.configData;
    })
    .catch(err => {
      return Promise.reject(err);
    });
}

// A helper property to return the config object
get config(): AppSettingsViewModel {
 //  console.log('Config Data' + JSON.stringify(this.configData));
  return this.configData;
}
}
