import { Injectable } from '@angular/core';
import { Observable, throwError} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {AuthService} from './auth.service';
import { ApolloError } from '../../apolloerror';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticatedHttpService {
    constructor(private authService: AuthService,
      private _http: HttpClient, private router: Router
  ) { }

      get(url): Observable<any> {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAccessToken()}`)
                                        .set('Cache-Control', 'no-store') // Related to no caching
                                        .set('Expires', '0') // Related to no caching
                                        .set('Pragma', 'no-cache'); // Related to no caching;
        return this._http.get(url , {headers: headers})
        .pipe(
          catchError(err => this.handleError(err))
        );

    }
    post(url, data) {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAccessToken()}`)
                                         .set('Content-Type', 'application/json');
        return this._http.post(url , data, {headers: headers})
        .pipe(
          catchError(err => this.handleError(err))
        );
    }

    put(url, data) {
       const headers =  new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAccessToken()}`)
                                         .set('Content-Type', 'application/json');
       return this._http.put(url , data, { headers: headers })
       .pipe(
        catchError(err => this.handleError(err))
      );
    }

    private handleError(error: HttpErrorResponse) {
      // Todo: If 401 then authservice.logoff and then redirect to home page only if 401 is due to token expiry??? .
       const dataError = new ApolloError();
      dataError.errorNumber = error.status;
      dataError.message = error.message;
      dataError.friendlyMessage = 'Please try again .If the problem persists ,Kindly contact support';

      if (error.status === 401) {
        this.authService.logout();
        dataError.friendlyMessage = 'Could not refresh Auth Token . Logging Off';
        this.router.navigate(['/home']);
        // Should we navigate to home page ?? and not throw error?
      } else {
        return throwError(dataError);
      }
 }
}
