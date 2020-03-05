import { Oefening } from '../models/oefening';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { Prestatie } from '../models/prestatie';

@Injectable()
export class OefeningApi {
    private subject = new Subject<Oefening[]>();
	private oefeningen: Oefening[];

	constructor(private http: HttpClient) {}

	query(): Observable<Oefening[]> {
		this.http
			.get<Oefening[]>('http://localhost:3000/oefeningen')
			.subscribe(oefeningen => {
				this.oefeningen = oefeningen;
				this.subject.next(oefeningen);
			});

		return this.subject;
	}

	add(oefening: Oefening) {
		this.http
			.post<Oefening>('http://localhost:3000/oefeningen', oefening)
			.subscribe(addedOefening => {
				this.oefeningen.push(addedOefening);
				this.subject.next(this.oefeningen);
			});
    }
    
    addPrestatie(oefening: Oefening, prestatie: Prestatie) {
        this.http
            .post<Prestatie>('http://localhost:3000/prestaties', prestatie)
            .subscribe(addedPrestatie => {
                if (!oefening.prestaties) {
                    oefening.prestaties = [addedPrestatie];
                }
                oefening.prestaties.push(addedPrestatie);
                this.subject.next(this.oefeningen);
            })
    }
}