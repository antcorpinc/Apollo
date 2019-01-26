import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { Subscription } from 'rxjs';
import { FlatViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatviewmodel';
import { FlatDataService } from 'src/app/backoffice/common/backoffice-shared/services/flat-data.service';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { ObjectState } from 'src/app/common/enums';
import { InfoMessages } from 'src/app/common/messages';

@Component({
  selector: 'app-flat-info',
  templateUrl: './flat-info.component.html',
  styleUrls: ['./flat-info.component.css']
})
export class FlatInfoComponent implements OnInit, OnDestroy {
  flatForm: FormGroup;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  societyOperation: string;
  buildingOperation: string;

  societyId: string;
  buildingId: string;
  flatId: string;

  subscriptions: Subscription[] = [];

  flatViewModel: FlatViewModel = <FlatViewModel>{};
  // This one is when we update in Db
  flatSaveViewModel: FlatViewModel = <FlatViewModel>{};

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private flatDataService: FlatDataService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.flatId = this.activatedRoute.snapshot.paramMap.get('id');
    this.societyOperation = this.activatedRoute.snapshot.paramMap.get('societyoperation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('societyid');
    this.buildingId = this.activatedRoute.snapshot.paramMap.get('buildingid');
    this.buildingOperation = this.activatedRoute.snapshot.paramMap.get('buildingoperation');
    this.createFormModel();
  }

  createFormModel() {
    this.flatForm = new FormGroup({
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
      name: new FormControl('', [Validators.required, Validators.maxLength(200)]),
    });

    if (this.operation.toLowerCase().trim() === this.read) {
      this.getFlatInSocietyBuilding(this.societyId, this.buildingId, this.flatId);
      this.flatForm.disable();
    } else if (this.operation.toLowerCase().trim() === this.edit) {
      this.getFlatInSocietyBuilding(this.societyId, this.buildingId, this.flatId);
    }
  }

  getFlatInSocietyBuilding(societyId: string, buildingId: string, flatId: string) {
     const subscription  = this.flatDataService.getFlatInSocietyBuilding(
      societyId, buildingId, flatId)
      .subscribe(data => {
        console.log('Flast  Data =>' + JSON.stringify(data));
        this.flatViewModel = data;
        this.flatForm.get('isActive').setValue(this.flatViewModel.isActive);
        this.flatForm.get('objectState').setValue(ObjectState.Unchanged);
        this.flatForm.get('name').setValue(this.flatViewModel.name);
      });
      this.subscriptions.push(subscription);
  }

  updateSaveObjectState() {
    this.flatSaveViewModel = Object.assign({}, this.flatViewModel, this.flatForm.value);
    if (this.operation === this.create) {
      this.flatSaveViewModel.objectState = ObjectState.Added;
    } else if (this.operation === this.edit) {
      this.flatSaveViewModel.objectState = ObjectState.Modified;
    }
  }

  onCancel() {
  }

  onSubmit() {
    if (this.flatForm.valid) {
      this.updateSaveObjectState();
      if (this.operation === this.create) {
        const subscription = this.flatDataService.createFlatInSocietyBuilding(
          this.societyId, this.buildingId , this.flatSaveViewModel)
          .subscribe(data => {
            this.snackBar.open(InfoMessages.flatCreationMessage, '', {
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
  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
