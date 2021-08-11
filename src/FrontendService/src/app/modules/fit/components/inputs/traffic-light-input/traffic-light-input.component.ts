import { Component, OnInit, Input, Output, EventEmitter, ViewChild, forwardRef } from '@angular/core';
import { ControlContainer, ControlValueAccessor, FormControl, FormGroupDirective, NG_VALUE_ACCESSOR, Validators } from '@angular/forms';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';

@Component({
  selector: 'app-traffic-light-input',
  templateUrl: './traffic-light-input.component.html',
  styleUrls: ['./traffic-light-input.component.css'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    multi: true,
    useExisting: forwardRef(() => TrafficLightInputComponent)
  }],
  viewProviders: [{
    provide: ControlContainer, 
    useExisting: FormGroupDirective 
  }]
})
export class TrafficLightInputComponent implements OnInit, ControlValueAccessor {
  
  @ViewChild('red') redSelector;
  @ViewChild('orange') orangeSelector;
  @ViewChild('green') greenSelector;

  @Input() public redValue: any;
  @Input() public orangeValue: any;
  @Input() public greenValue: any;

  constructor() { }

  onChange = (value: any) => {};

  writeValue(obj: any): void {
    // console.log('writeValue', obj);
    try {
      switch(obj){
        case this.redValue:
          this.selectRed();
          break;
        case this.orangeValue:
          this.selectOrange();
          break;
        case this.greenValue:
          this.selectGreen();
          break;
        default:
          this.selectNone();
      }
    } catch {

    }
  }
  registerOnChange(fn: any): void {
    // console.log('registerOnChange', fn);
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    // throw new Error('Method not implemented.');
    // console.log('registerOnTouched', fn);
  }
  setDisabledState?(isDisabled: boolean): void {
    // throw new Error('Method not implemented.');
    // console.log('setDisabledState', isDisabled);
  }

  ngOnInit(): void {
  }

  selectRed() {
    this.onChange(this.redValue);
    this.highlightRed();
    this.dimOrange();
    this.dimGreen();
  }

  selectOrange() {
    this.onChange(this.orangeValue);
    this.dimRed();
    this.highlightOrange();
    this.dimGreen();
  }

  selectGreen() {
    this.onChange(this.greenValue);
    this.dimRed();
    this.dimOrange();
    this.highlightGreen();
  }

  private selectNone() {
    this.dimRed();
    this.dimOrange();
    this.dimGreen();
  }

  private dimRed() {
    // this.redSelector._elementRef.nativeElement.style.backgroundColor = '#c0392b';
    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#7f8c8d';
    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#555555';
  }
  
  private dimOrange() {
    // this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#d35400';
    this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#7f8c8d';
    this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#555555';
  }

  private dimGreen() {
    // this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#27ae60';
    this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#7f8c8d';
    this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#555555';
  }

  private highlightRed() {
    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#EA2027';
    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#ED4C67';

    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#ff5252';

    this.redSelector._elementRef.nativeElement.style.backgroundColor = '#eb3b5a';
  }

  private highlightOrange() {
    this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#F79F1F';

    this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#ff793f';

    this.orangeSelector._elementRef.nativeElement.style.backgroundColor = '#fa8231';
  }

  private highlightGreen() {
    this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#009432';
    this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#A3CB38';

    // this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#33d9b2';

    this.greenSelector._elementRef.nativeElement.style.backgroundColor = '#20bf6b';
  }
}
