import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { FarmService, AlertService } from '@app/_services';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form: FormGroup;
    id: string;
    isAddMode: boolean;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private farmService: FarmService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        
    

        this.form = this.formBuilder.group({
            name: ['', Validators.required],
            owner: ['', Validators.required],
            size: ['', Validators.required],
            sizeUnit:['', Validators.required],
            country:[''],
            province:[''],
            city:[''],
            latitude: [''],
            longitude: ['']
            
        });

        if (!this.isAddMode) {
            this.farmService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.f.name.setValue(x.name);
                    this.f.owner.setValue(x.owner);
                    this.f.size.setValue(x.size);
                    this.f.sizeUnit.setValue(x.sizeUnit);
                    this.f.country.setValue(x.country);
                    this.f.province.setValue(x.province);
                    this.f.city.setValue(x.city);
                    this.f.latitude.setValue(x.latitude);
                    this.f.longitude.setValue(x.longitude);
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createFarm();
        } else {
            this.updateFarm();
        }
    }

    private createFarm() {
        this.farmService.create(this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Farm added successfully', { keepAfterRouteChange: true });
                    this.router.navigate(['.', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }

    private updateFarm() {
        this.farmService.update(this.id, this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update successful', { keepAfterRouteChange: true });
                    this.router.navigate(['..', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}