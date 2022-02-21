import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input-uppercase',
  templateUrl: './text-input-uppercase.component.html',
  styleUrls: ['./text-input-uppercase.component.scss']
})
export class TextInputUppercaseComponent implements ControlValueAccessor {
  @Input() label: string;
  @Input() type = 'text';
  @Input() width: string;
  @Input() maxLength = 50;


  constructor(@Self() public ngControl: NgControl) { 
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }
}