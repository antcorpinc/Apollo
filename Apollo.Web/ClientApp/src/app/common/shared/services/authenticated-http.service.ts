import { Injectable } from '@angular/core';
import { Observable, throwError} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {AuthService} from './auth.service';
import { ApolloError } from '../../apolloerror';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticatedHttpService {
    constructor(private authService: AuthService,
    private _http: HttpClient
  ) { }

      get(url): Observable<any> {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAccessToken()}`);
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
       const dataError = new ApolloError();
      dataError.errorNumber = error.status;
      dataError.message = error.message;
      dataError.friendlyMessage = 'Please contact support @ Mg';
      return throwError(dataError);
 }
}