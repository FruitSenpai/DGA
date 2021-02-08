import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { FarmService } from '@app/_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    farms = null;

    constructor(private farmService: FarmService) {}

    ngOnInit() {
        this.farmService.getAll()
            .pipe(first())
            .subscribe(farms => this.farms = farms);
    }

    deleteFarm(id: string) {
        const farm = this.farms.find(x => x.id === id);
        farm.isDeleting = true;
        this.farmService.delete(id)
            .pipe(first())
            .subscribe(() => {
                this.farms = this.farms.filter(x => x.id !== id) 
            });
    }
}