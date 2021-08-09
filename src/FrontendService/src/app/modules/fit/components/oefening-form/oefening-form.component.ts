import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Oefening } from 'src/app/models/oefening';

@Component({
  selector: 'app-oefening-form',
  templateUrl: './oefening-form.component.html',
  styleUrls: ['./oefening-form.component.css']
})
export class OefeningFormComponent implements OnInit {
  @Input() oefening: Oefening;
  @Output() submitClicked: EventEmitter<Oefening> = new EventEmitter();
  @Output() cancelClicked: EventEmitter<void> = new EventEmitter();

  public form = new FormGroup({
    naam: new FormControl(),
    omschrijving: new FormControl()
  });

  constructor() { }

  ngOnInit(): void {
    if (this.oefening !== undefined) {
      // TODO fill form
    }
  }

  cancel() {
    this.cancelClicked.emit();
  }

  submit() {
    this.submitClicked.emit(this.form.value);
  }
}
