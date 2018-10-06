import { Injectable } from '@angular/core';
import {Subject} from 'rxjs';
import { ITopBarItem, TopBarItemViewModel } from '../viewmodels/topbaritemviewmodel';

@Injectable({
  providedIn: 'root'
})
export class TopBarService {
  private appChangeSource = new Subject<null>();
  appChange$ = this.appChangeSource.asObservable();
  _item: ITopBarItem;
  constructor() { }

  getTopBarItem(): ITopBarItem {
    return this._item;
  }
  setTopBarItem(item: ITopBarItem) {
    this._item = item;
  }

  onAppChange($event): void {
    this.appChangeSource.next($event.target.value);
}
}
