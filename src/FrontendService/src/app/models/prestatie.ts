import { OefeningZwaarte } from "../enums/oefening-zwaarte";

export class Prestatie {
    id: string;
    oefeningId: string;
    datum: Date;
    gewicht: number;
    herhalingen: number;
    opmerking: string;
    sets: number;
    oefeningZwaarte: OefeningZwaarte;
}