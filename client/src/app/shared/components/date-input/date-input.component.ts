import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { roLocale } from 'ngx-bootstrap/locale';
defineLocale('ro', roLocale);


@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.scss']
})
export class DateInputComponent implements ControlValueAccessor {
  @Input() label: string;
  bsConfig: Partial<BsDatepickerConfig>;
  

  constructor(@Self() public ngControl: NgControl, private bsLocaleService: BsLocaleService) { 
    this.bsLocaleService.use('ro');

    this.ngControl.valueAccessor = this;
    this.bsConfig = {
      containerClass: 'theme-dark-blue',
      dateInputFormat: 'DD.MM.YYYY',
    }
  }
  
  writeValue(obj: any): void {  
  }

  registerOnChange(fn: any): void {  
  }

  registerOnTouched(fn: any): void {
  }

}


