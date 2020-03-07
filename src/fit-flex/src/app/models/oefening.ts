import { Prestatie } from './prestatie';

export class Oefening {
    id: string;
    naam: string;
    omschrijving: string;
    prestaties: Prestatie[];
}