import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.css']
})
export class NumberInputComponent implements OnInit {

  @Input() label: string;
  @Input() waarde: number;
  @Input() minimum: number;
  @Input() suffix: string;
  @Output() verandert: EventEmitter<number> = new EventEmitter();
  @Output() focussed: EventEmitter<void> = new EventEmitter();
  @Output() focusLost: EventEmitter<void> = new EventEmitter();

  waardeControl = new FormControl(0, 
    [
      Validators.min(0),
      Validators.required
    ]
  );

  lastwaardeValue: number;
  
  constructor() { }

  ngOnInit(): void {
    this.waarde = Number(this.waarde);
    this.waardeControl.setValue(this.waarde);

    this.lastwaardeValue = this.waarde;
  }

  inputBlurred(value) : void {
    let valueAsNumber = Number(value);
    if (valueAsNumber !== this.lastwaardeValue && this.waardeControl.valid) {
      console.log(`${this.label} is veranderd naar ${valueAsNumber}`);
      this.lastwaardeValue = valueAsNumber;

      this.verandert.emit(valueAsNumber);
    } else {
      console.log(`${this.label} is niet veranderd`);
    }

    this.focusLost.emit();
  }

  onFocus() : void {
    this.focussed.emit();
  }
}
