import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { Subscription, Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { MatDialog, MatSnackBar } from '@angular/material';
import { ObjectState } from 'src/app/common/enums';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { debounceTime } from 'rxjs/operators';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { Utilities } from 'src/app/common/utilities/utilities';

@Component({
  selector: 'app-society-user-info',
  templateUrl: './society-user-info.component.html',
  styleUrls: ['./society-user-info.component.css']
})
export class SocietyUserInfoComponent implements OnInit, AfterViewInit , OnDestroy {

  societyUserForm: FormGroup;
  societyList$: Observable<SocietyListViewModel[]>;

  userId: string;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  // This is one we get initially ,
 //  societyUserViewModel: SocietyUserViewModel = <SocietyUserViewModel>{};
  // This one is when we update in Db
 //  societyUserSaveViewModel: SocietyUserViewModel = <SocietyUserViewModel>{};

 subscriptions: Subscription[] = [];

  constructor(private activatedRoute: ActivatedRoute, private dialog: MatDialog,
     private snackBar: MatSnackBar, private societyDataService: SocietyDataService) { }

  ngOnInit() {
      // Read Route parameters
      this.userId = this.activatedRoute.snapshot.params['id'];
      this.operation = this.activatedRoute.snapshot.params['operation'];
      this.createFormModel();
  }
  ngAfterViewInit(): void {
    this.societyUserForm.get('societyId').valueChanges.pipe(
      debounceTime(1000)
    ).subscribe(value => this.getSocietyListBasedOnSearch(value));
  }

  createFormModel() {
    this.societyUserForm = new FormGroup({
       societyId: new FormControl('', [Validators.required, Validators.maxLength(100)]),
       building: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      flat: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      firstName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(50), Validators.email]),
      phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      role: new FormControl('', [Validators.required]),
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
    });
  }

  getSocietyListBasedOnSearch(search: string) {
    if (!Utilities.isNullOrEmpty(search) && search.length > 2 ) {
      this.societyList$ =  this.societyDataService.getSocietiesByCustomSearch(search);
     }
  }
  onSubmit() {

  }

  ngOnDestroy(): void {

  }
}
