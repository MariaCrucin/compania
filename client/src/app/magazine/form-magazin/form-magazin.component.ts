import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IMagazinDto } from 'src/app/shared/models/magazin';

@Component({
  selector: 'app-form-magazin',
  templateUrl: './form-magazin.component.html',
  styleUrls: ['./form-magazin.component.scss']
})
export class FormMagazinComponent implements OnInit {

  @Input() magazin: IMagazinDto;
  @Input() clientId: number;
  @Input() errors: string[];
  
  magazinForm: FormGroup;

  @Output() onSaveChanges: EventEmitter<IMagazinDto> = new EventEmitter<IMagazinDto>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.magazinForm = this.fb.group({
      numar: [null, [Validators.required, Validators.min(1000), Validators.max(9999)]],
      den: ['', [Validators.required, Validators.maxLength(50)]],
      comandaCadru: [null, [Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
      clientId: 0
    });

    if (this.magazin !== undefined) {
      this.magazinForm.patchValue(this.magazin);
    } else {
      this.magazinForm.get('clientId').setValue(this.clientId);
    }
  }

  saveMagazin() {
    this.onSaveChanges.emit(this.magazinForm.value);
  }

}
