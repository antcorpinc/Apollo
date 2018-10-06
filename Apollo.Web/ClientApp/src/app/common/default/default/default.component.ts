import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../../shared/services/user-profile.service';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {

  constructor(private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.userProfileService.getUserProfile();
  }

}
