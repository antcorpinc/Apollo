import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {
  private _code: string;
  private _message: string;
  private _link: string;
  constructor() { }

  get code(): string {
    return this._code;
  }

  set code(code: string) {
    this._code = code;
  }

  get message():  string {
    return this._message;
  }

  set message(message: string) {
    this._message = message;
  }

  get link():  string {
    return this._link;
  }

  set link(link: string) {
    this._link = link;
  }
}
