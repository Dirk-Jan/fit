import { Oefening } from '../models/oefening';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Subject, Observable, throwError } from 'rxjs';
import { Prestatie } from '../models/prestatie';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class OefeningApi {
	private baseUrl: string = environment.baseUrl;

    private subject = new Subject<Oefening[]>();
	private oefeningen: Oefening[];

	constructor(private http: HttpClient) {}

	query(): Observable<Oefening[]> {
		return this.http.get<Oefening[]>(this.baseUrl + '/oefeningen');
	}

	getById(id: string): Observable<Oefening> {
		return this.http.get<Oefening>(this.baseUrl + '/oefeningen/' + id);
	}

	add(oefening: Oefening): Observable<Oefening> {
		console.log('hallo oefening ', oefening)
		return this.http.post<Oefening>(this.baseUrl + '/oefeningen', oefening);
    }
    
    addPrestatie(oefening: Oefening, prestatie: Prestatie): Observable<any> {
		prestatie.oefeningId = oefening.id;
        return this.http.post<Prestatie>(this.baseUrl + '/prestaties', prestatie);
	}
}