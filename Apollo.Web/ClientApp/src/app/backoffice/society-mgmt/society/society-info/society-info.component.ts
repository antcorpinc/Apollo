import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { StateViewModel } from 'src/app/common/viewmodels/stateviewmodel';
import { SocietyViewModel } from 'src/app/backoffice/viewmodel/society-vm/societyviewmodel';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ObjectState } from 'src/app/common/enums';
import { LookupMasterService } from 'src/app/common/shared/services/lookup-master.service';
import { CityViewModel } from 'src/app/common/viewmodels/cityviewmodel';
import { AreaViewModel } from 'src/app/common/viewmodels/areaviewmodel';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';

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
     private societyDataService: SocietyDataService) { }

  ngOnInit() {
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
      pincode: new FormControl('', [Validators.maxLength(20)]),
      phoneNumber: new FormControl('', [Validators.maxLength(20)]),
      additionalPhoneNumber: new FormControl('', [Validators.maxLength(20)]),
    });
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
  onSubmit() {
    if (this.societyForm.valid) {
      this.updateSaveObjectState();
      if (this.operation === this.create) {
        const subscription = this.societyDataService.createSociety(this.societySaveViewModel);
      }
    }
  }
  updateSaveObjectState() {
    this.societySaveViewModel = Object.assign({}, this.societyViewModel, this.societyForm.value);
    if (this.operation === this.create) {
      this.societySaveViewModel.objectState = ObjectState.Added;
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
