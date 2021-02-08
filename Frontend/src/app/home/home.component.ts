import { Component } from '@angular/core';

import { User, Farm } from '@app/_models';
import { AccountService, FarmService } from '@app/_services';


@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: User;
    farm: Farm;

    constructor(private accountService: AccountService, private farmService: FarmService) {
        this.user = this.accountService.userValue;
        this.farm = this.farmService.farmValue;
    }
    //constructor(private farmService: FarmService){
      //  this.farm = this.farmService.farmValue;
    //}
}