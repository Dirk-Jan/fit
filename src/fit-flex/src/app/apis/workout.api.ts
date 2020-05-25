import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Subject, Observable } from 'rxjs';
import { Oefening } from '../models/oefening';
import { HttpClient } from '@angular/common/http';
import { Prestatie } from '../models/prestatie';
import { Workout } from '../models/workout';

@Injectable()
export class WorkoutApi {
	private baseUrl: string = environment.baseUrl;

	constructor(private http: HttpClient) {}

	getAllWorkoutDatums(): Observable<Date[]> {
		return this.http.get<Date[]>(this.baseUrl + '/workouts');
	}

	getById(datum: Date): Observable<Workout> {
		return this.http.get<Workout>(this.baseUrl + '/workouts/' + datum);
	}
}