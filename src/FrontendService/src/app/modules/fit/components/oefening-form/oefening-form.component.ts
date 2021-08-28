import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { fromEventPattern } from 'rxjs';
import { Oefening } from 'src/app/models/oefening';

@Component({
  selector: 'app-oefening-form',
  templateUrl: './oefening-form.component.html',
  styleUrls: ['./oefening-form.component.css']
})
export class OefeningFormComponent implements OnInit {
  private _oefening: Oefening;

  get oefening(): Oefening {
      return this._oefening;
  }
  @Input() set oefening(value: Oefening) {
      this._oefening = value;
      this.updateForm();
  }
  @Output() submitClicked: EventEmitter<Oefening> = new EventEmitter();
  @Output() cancelClicked: EventEmitter<void> = new EventEmitter();

  naamFormControl = new FormControl();
  omschrijvingFormControl = new FormControl();

  public form: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.updateForm();
  }

  private updateForm(): void {
    console.log('update form', this.oefening);
    if (this.oefening !== undefined) {
      this.naamFormControl.setValue(this.oefening.naam);
      this.omschrijvingFormControl.setValue(this.oefening.omschrijving);
    }

    this.form = new FormGroup({
      naam: this.naamFormControl,
      omschrijving: this.omschrijvingFormControl
    });
  }

  public cancel(): void {
    this.cancelClicked.emit();
  }

  public submit(): void {
    this.submitClicked.emit(this.form.value);
  }
}
