import { Spiergroep } from '../enums/spiergroep';
import { PrestatieDag } from './prestatie-dag';

export class Oefening {
    id: string;
    naam: string;
    omschrijving: string;
    spiergroep: Spiergroep;
    prestatieDagen: PrestatieDag[];
}