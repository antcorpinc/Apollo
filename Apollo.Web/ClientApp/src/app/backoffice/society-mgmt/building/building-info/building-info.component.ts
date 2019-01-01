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

  societyId: string;
  subscriptions: Subscription[] = [];

  buildingViewModel: BuildingViewModel = <BuildingViewModel>{};
  // This one is when we update in Db
  buildingSaveViewModel: BuildingViewModel = <BuildingViewModel>{};

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private buildingDataService: BuildingDataService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('societyid');
    this.createFormModel();
  }

  createFormModel() {
    this.buildingForm = new FormGroup({
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
      name: new FormControl('', [Validators.required, Validators.maxLength(200)]),
      description: new FormControl('', [Validators.maxLength(200)]),
    });
  }

  onFlats() {
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
      }
    }
  }

  updateSaveObjectState() {
    this.buildingSaveViewModel = Object.assign({}, this.buildingViewModel, this.buildingForm.value);
    if (this.operation === this.create) {
      this.buildingSaveViewModel.objectState = ObjectState.Added;
    }
  }

  onCancel() {
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
