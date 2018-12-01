import { Component, OnInit } from '@angular/core';
import { fadeAnimation } from '../../animations';

@Component({
  selector: 'app-authenticated-user',
  templateUrl: './authenticated-user.component.html',
  styleUrls: ['./authenticated-user.component.css'],
  animations: [fadeAnimation]
})
export class AuthenticatedUserComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
