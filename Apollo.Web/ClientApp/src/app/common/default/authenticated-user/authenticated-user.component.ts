import { Component, OnInit } from '@angular/core';
import { slideInAnimation } from '../../animations';

@Component({
  selector: 'app-authenticated-user',
  templateUrl: './authenticated-user.component.html',
  styleUrls: ['./authenticated-user.component.css'],
  animations: [slideInAnimation]
})
export class AuthenticatedUserComponent implements OnInit {
  showSpinner = true;
  constructor() {
   }

  ngOnInit() {
  }

}
