import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { StateViewModel } from 'src/app/common/viewmodels/stateviewmodel';
import { SocietyViewModel } from 'src/app/backoffice/viewmodel/society-vm/societyviewmodel';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ObjectState } from 'src/app/common/enums';
import { LookupMasterService } from 'src/app/common/shared/services/lookup-master.service';
import { CityViewModel } from 'src/app/common/viewmodels/cityviewmodel';
import { AreaViewModel } from 'src/app/common/viewmodels/areaviewmodel';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { InfoMessages } from 'src/app/common/messages';
import { MatSnackBar } from '@angular/material';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';

@Component({
  selector: 'app-society-info',
  templateUrl: './society-info.component.html',
  styleUrls: ['./society-info.component.css']
})
export class SocietyInfoComponent implements OnInit, OnDestroy {

  societyForm: FormGroup;
  states: StateViewModel[];
  cities: CityViewModel[];
  areas: AreaViewModel[];
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  societyId: string;
  // This is one we get initially ,
  societyViewModel: SocietyViewModel = <SocietyViewModel>{};
  // This one is when we update in Db
  societySaveViewModel: SocietyViewModel = <SocietyViewModel>{};
  subscriptions: Subscription[] = [];

  constructor(private activatedRoute: ActivatedRoute,
    private lookupMasterService: LookupMasterService,
    private societyDataService: SocietyDataService, private router: Router,
    private snackBar: MatSnackBar, private userProfileService: UserProfileService, ) { }

  ngOnInit() {
    // Read Route parameters
    this.societyId = this.activatedRoute.snapshot.params['id'];
    this.operation = this.activatedRoute.snapshot.params['operation'];
    // Get Master Data
    this.getStates();
    this.createFormModel();
  }

  getStates() {
    this.states = this.activatedRoute.snapshot.data['states'];
    console.log(`States are ${JSON.stringify(this.states)}`);
  }
  createFormModel() {
    this.societyForm = new FormGroup({
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
      name: new FormControl('', [Validators.required, Validators.maxLength(200)]),
      description: new FormControl('', [Validators.maxLength(200)]),
      addressLine1: new FormControl('', [Validators.required, Validators.maxLength(200)]),
      addressLine2: new FormControl('', [Validators.maxLength(200)]),
      landmark: new FormControl('', [Validators.maxLength(200)]),
      stateId: new FormControl(null, [Validators.required]),
      cityId: new FormControl(null, [Validators.required]),
      areaId: new FormControl(null, [Validators.required]),
      pinCode: new FormControl('', [Validators.maxLength(20)]),
      phoneNumber: new FormControl('', [Validators.maxLength(20)]),
      additionalPhoneNumber: new FormControl('', [Validators.maxLength(20)]),
    });

    if (this.operation.toLowerCase().trim() === this.read) {
      this.getSociety(this.societyId);
      this.societyForm.disable();
    } else if (this.operation.toLowerCase().trim() === this.edit) {
      this.getSociety(this.societyId);
    }
  }
  getCitiesForSelectedState(stateId) {
    const subscription = this.lookupMasterService.getCitiesForState(stateId).subscribe(
      (data) => {
        this.cities = data;
        console.log(`Cities For State = ${JSON.stringify(this.cities)}`);
      },
      (error) => {
        console.log('Error' + error);
      });
    this.subscriptions.push(subscription);
  }
  getAreasForSelectedCityState(stateId, cityId) {
    console.log(`StateId is ${stateId} and cityId is ${cityId}`);
    const subscription = this.lookupMasterService.getAreasForCityState(stateId, cityId).subscribe(
      (data) => {
        this.areas = data;
        console.log(`Areas are = ${this.areas}`);
      },
      (error) => {
        console.log('Error' + error);
      });
    this.subscriptions.push(subscription);
  }

  getSociety(societyId: string) {
    const subscription = this.societyDataService.getSocietyById(societyId)
      .subscribe(data => {
        console.log('Society Data =>' + JSON.stringify(data));
        this.societyViewModel = data;
        this.societyForm.get('isActive').setValue(this.societyViewModel.isActive);
        this.societyForm.get('objectState').setValue(ObjectState.Unchanged);
        this.societyForm.get('name').setValue(this.societyViewModel.name);
        this.societyForm.get('description').setValue(this.societyViewModel.description);
        this.societyForm.get('addressLine1').setValue(this.societyViewModel.addressLine1);
        this.societyForm.get('addressLine2').setValue(this.societyViewModel.addressLine2);
        this.societyForm.get('landmark').setValue(this.societyViewModel.landmark);
        this.societyForm.get('stateId').setValue(this.societyViewModel.stateId);
        // Get Cities for State
        this.getCitiesForSelectedState(this.societyViewModel.stateId);
        this.societyForm.get('cityId').setValue(this.societyViewModel.cityId);
        // Get Areas for State and City
        this.getAreasForSelectedCityState(this.societyViewModel.stateId,
          this.societyViewModel.cityId);
        this.societyForm.get('areaId').setValue(this.societyViewModel.areaId);
        this.societyForm.get('pinCode').setValue(this.societyViewModel.pinCode);
        this.societyForm.get('phoneNumber').setValue(this.societyViewModel.phoneNumber);
        this.societyForm.get('additionalPhoneNumber').setValue(this.societyViewModel.additionalPhoneNumber);
      });
    this.subscriptions.push(subscription);
  }
  onSubmit() {
    if (this.societyForm.valid) {
      this.updateSaveObjectState();
      if (this.operation === this.create) {
        console.log(JSON.stringify(this.societySaveViewModel));
        const subscription = this.societyDataService.createSociety(this.societySaveViewModel)
          .subscribe(data => {
            this.snackBar.open(InfoMessages.userCreationMessage, '', {
              duration: CONSTANTS.snackbar.timeout, verticalPosition: 'top',
              politeness: 'polite', panelClass: 'showSnackBar'
            });
            this.router.navigate(['/auth/bo/societymgmt/societies'], { relativeTo: this.activatedRoute });
          });
      } else if (this.operation === this.edit) {
        console.log('edit society model = ' + JSON.stringify(this.societySaveViewModel));
        const subscription = this.societyDataService.updateSociety(this.societySaveViewModel)
          .subscribe(data => {

            this.snackBar.open(InfoMessages.userUpdationMessage, '', {
              duration: CONSTANTS.snackbar.timeout, verticalPosition: 'top',
              politeness: 'polite', panelClass: 'showSnackBar'
            });
            this.router.navigate(['/auth/bo/societymgmt/societies'],
              { relativeTo: this.activatedRoute });
          },
            (error) => {
              console.log('Error' + error);
            });
        this.subscriptions.push(subscription);
      }
    }
  }
  updateSaveObjectState() {
    this.societySaveViewModel = Object.assign({}, this.societyViewModel, this.societyForm.value);
    if (this.operation === this.create) {
      this.societySaveViewModel.objectState = ObjectState.Added;
      this.societySaveViewModel.id = this.societyId;
      this.societySaveViewModel.createdBy = this.userProfileService.getBasicUserInfo().id;
      this.societySaveViewModel.updatedBy = this.userProfileService.getBasicUserInfo().id;
    } else if (this.operation === this.edit) {
      this.societySaveViewModel.createdBy = this.societyViewModel.createdBy;

      this.societySaveViewModel.updatedBy = this.userProfileService.getBasicUserInfo().id;
      if (this.societyForm.get('isActive').value !== this.societyViewModel.isActive ||
        this.societyForm.get('name').value !== this.societyViewModel.name ||
        this.societyForm.get('description').value !== this.societyViewModel.description ||
        this.societyForm.get('addressLine1').value !== this.societyViewModel.addressLine1 ||
        this.societyForm.get('addressLine1').value !== this.societyViewModel.addressLine1 ||
        this.societyForm.get('addressLine2').value !== this.societyViewModel.addressLine2 ||
        this.societyForm.get('landmark').value !== this.societyViewModel.landmark ||
        this.societyForm.get('stateId').value !== this.societyViewModel.stateId ||
        this.societyForm.get('cityId').value !== this.societyViewModel.cityId ||
        this.societyForm.get('areaId').value !== this.societyViewModel.areaId ||
        this.societyForm.get('pinCode').value !== this.societyViewModel.pinCode ||
        this.societyForm.get('phoneNumber').value !== this.societyViewModel.phoneNumber ||
        this.societyForm.get('additionalPhoneNumber').value !== this.societyViewModel.additionalPhoneNumber
      ) {
        this.societySaveViewModel.objectState = ObjectState.Modified;
      }
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
