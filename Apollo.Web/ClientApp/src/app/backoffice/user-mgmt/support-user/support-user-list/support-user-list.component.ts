import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-support-user-list',
  templateUrl: './support-user-list.component.html',
  styleUrls: ['./support-user-list.component.css']
})
export class SupportUserListComponent implements OnInit, OnDestroy {
  // Todo clear subcription on destroy
  subscriptions: Subscription[] = [];

 constructor(private userDataService: UserDataService ) { }

  ngOnInit() {
    this.getSupportUserList();
  }

  getSupportUserList() {
    // Todo Handle Error
    this.userDataService.getSupportUsers()
      .subscribe(data => console.log('Users are ' + JSON.stringify(data)));
  }

  ngOnDestroy(): void {

  }

}
