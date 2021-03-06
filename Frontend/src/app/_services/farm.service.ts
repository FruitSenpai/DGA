import { Injectable } from '@angular/core';
//import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Farm } from '@app/_models';

@Injectable({ providedIn: 'root' })

export class FarmService {
    private farmSubject: BehaviorSubject<Farm>;
    public farm: Observable<Farm>;

    constructor(
        
        private http: HttpClient
    ) {
        this.farmSubject = new BehaviorSubject<Farm>(JSON.parse(localStorage.getItem('farm')));
        this.farm = this.farmSubject.asObservable();
    }

    public get farmValue(): Farm {
        return this.farmSubject.value;
    }

    

   

    create(farm: Farm) {
        return this.http.post(`${environment.apiUrl}/farms/create`, farm);
    }

    getAll() {
        return this.http.get<Farm[]>(`${environment.apiUrl}/farms`);
    }

    getById(id: string) {
        return this.http.get<Farm>(`${environment.apiUrl}/farms/${id}`);
    }

    update(id, params) {
        return this.http.put(`${environment.apiUrl}/farms/${id}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
                if (id == this.farmValue.id) {
                    // update local storage
                    const farm = { ...this.farmValue, ...params };
                    localStorage.setItem('farm', JSON.stringify(farm));

                    // publish updated farm to subscribers
                    this.farmSubject.next(farm);
                }
                return x;
            }));
    }

    delete(id: string) {
        return this.http.delete(`${environment.apiUrl}/farms/${id}`)
            .pipe(map(x => {
                
                return x;
            }));
    }
}