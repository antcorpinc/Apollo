import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { Subscription } from 'rxjs';
import { ObjectState } from 'src/app/common/enums';
import { BuildingViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildingviewmodel';
import { BuildingDataService } from 'src/app/backoffice/common/backoffice-shared/services/building-data.service';
import { MatSnackBar } from '@angular/material';
import { InfoMessages } from 'src/app/common/messages';

@Component({
  selector: 'app-building-info',
  templateUrl: './building-info.component.html',
  styleUrls: ['./building-info.component.css']
})
export class BuildingInfoComponent implements OnInit, OnDestroy {
  buildingForm: FormGroup;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  societyOperation: string;

  societyId: string;
  buildingId: string;

  subscriptions: Subscription[] = [];

  buildingViewModel: BuildingViewModel = <BuildingViewModel>{};
  // This one is when we update in Db
  buildingSaveViewModel: BuildingViewModel = <BuildingViewModel>{};

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private buildingDataService: BuildingDataService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.societyOperation = this.activatedRoute.snapshot.paramMap.get('societyoperation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('societyid');
    this.buildingId = this.activatedRoute.snapshot.paramMap.get('id');
    this.createFormModel();
  }

  createFormModel() {
    this.buildingForm = new FormGroup({
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
      name: new FormControl('', [Validators.required, Validators.maxLength(200)]),
      description: new FormControl('', [Validators.maxLength(200)]),
    });

    if (this.operation.toLowerCase().trim() === this.read) {
      this.getBuildingInSociety(this.societyId, this.buildingId);
      this.buildingForm.disable();
    } else if (this.operation.toLowerCase().trim() === this.edit) {
      this.getBuildingInSociety(this.societyId, this.buildingId);
    }
  }

  getBuildingInSociety(societyId: string , buildingId: string) {
    const subscription  = this.buildingDataService.getBuildingInSociety(societyId, buildingId)
      .subscribe(data => {
        console.log('Building  Data =>' + JSON.stringify(data));
        this.buildingViewModel = data;
        this.buildingForm.get('isActive').setValue(this.buildingViewModel.isActive);
        this.buildingForm.get('objectState').setValue(ObjectState.Unchanged);
        this.buildingForm.get('name').setValue(this.buildingViewModel.name);
        this.buildingForm.get('description').setValue(this.buildingViewModel.description);
      });
      this.subscriptions.push(subscription);
  }

  onFlats() {
    this.buildingDataService.BuildingName = this.buildingViewModel.name;
    /* this.router.navigate(['/auth/bo/societymgmt/society', this.societyId, this.societyOperation, 'building',
    this.buildingId, this.operation, 'flats' ],
                         { relativeTo: this.activatedRoute }); */
    this.router.navigate(['flats' ], { relativeTo: this.activatedRoute });
  }
  onSubmit() {
    if (this.buildingForm.valid) {
      this.updateSaveObjectState();
      if (this.operation === this.create) {
        const subscription = this.buildingDataService.createBuildingInSociety(
          this.societyId, this.buildingSaveViewModel)
          .subscribe(data => {
            this.snackBar.open(InfoMessages.buildingCreationMessage, '', {
              duration: CONSTANTS.snackbar.timeout, verticalPosition: 'top',
              politeness: 'polite', panelClass: 'showSnackBar'
            });
          },
            (error) => {
              console.log('Error' + error);
            });
            this.subscriptions.push(subscription);
      } else if (this.operation === this.edit) {
        const subscription = this.buildingDataService.updateBuildingInSociety(this.societyId,
          this.buildingId, this.buildingSaveViewModel).subscribe(data => {
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
    this.buildingSaveViewModel = Object.assign({}, this.buildingViewModel, this.buildingForm.value);
    if (this.operation === this.create) {
      this.buildingSaveViewModel.objectState = ObjectState.Added;
    } else if (this.operation === this.edit) {
      this.buildingSaveViewModel.objectState = ObjectState.Modified;
     // this.buildingSaveViewModel.createdBy = this.buildingViewModel.createdBy;
     // this.buildingSaveViewModel.createdDate = this.buildingViewModel.createdDate;
    }
  }

  onCancel() {
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
