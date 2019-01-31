import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { debounceTime } from 'rxjs/operators';
import { Utilities } from 'src/app/common/utilities/utilities';
import { UserDataService } from 'src/app/backoffice/common/backoffice-shared/services/user-data.service';

@Component({
  selector: 'app-society-user-list',
  templateUrl: './society-user-list.component.html',
  styleUrls: ['./society-user-list.component.css']
})
export class SocietyUserListComponent implements OnInit {
  societyName = new FormControl();
  societyList$: Observable<SocietyListViewModel[]>;

  constructor(private societyDataService: SocietyDataService, private userDataService: UserDataService) { }
// Todo: Add Subscriptions
  ngOnInit() {
    this.societyName.valueChanges.pipe(
      debounceTime(1000)
    ).subscribe(value => this.getSocietyListBasedOnSearch(value));
  }

  getSocietyListBasedOnSearch(search: string) {
    if (!Utilities.isNullOrEmpty(search) && search.length > 2 ) {
     this.societyList$ =  this.societyDataService.getSocietiesByCustomSearch(search);
    }
  }

  search(event, data) {
    if (event.source.selected) {
      // Get the Users for the society -- Do we also need to get the Building for society ??
      // May be no need since in users list we'll also get the building and flat and can sort by building?
      this.userDataService.getUsersInSociety(data.id).subscribe((resp) => console.log(resp));
    }
  }

}
