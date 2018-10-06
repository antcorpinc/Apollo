import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {AuthService} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticatedHttpService {
    constructor(private authService: AuthService,
    private _http: HttpClient
  ) { }

      get(url, relativeuri= ''): Observable<any> {
         const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAccessToken()}`)
                                        .set('relative-uri', relativeuri);
       return this._http.get(url , {headers: headers})  ;

    }
    post(url, data, relativeuri= '') {
          const headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken())
                                        .set('Content-Type', 'application/json')
                                        .set('relative-uri', relativeuri);
             return this._http.post(url , data, {headers: headers});
    }

    put(url, data, relativeuri= '') {
      const headers =  new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken())
                                        .set('Content-Type', 'application/json')
                                        .set('relative-uri', relativeuri);
        return this._http.put(url , data, { headers: headers });
    }
}
