import { Component } from '@angular/core';

import { AccountService, FarmService } from './_services';
import { User, Farm } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    user: User;
    farm: Farm;

    constructor(private accountService: AccountService, private farmService: FarmService) {
        this.accountService.user.subscribe(x => this.user = x);
        this.farmService.farm.subscribe(y=>this.farm = y);
    }

    logout() {
        this.accountService.logout();
    }
}