import { IServiciu } from './../../shared/models/tarif';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IServiciuToSaveDto } from 'src/app/shared/models/tarif';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-serviciu',
  templateUrl: './form-serviciu.component.html',
  styleUrls: ['./form-serviciu.component.scss']
})
export class FormServiciuComponent implements OnInit {
  @Input() errors: string[];
  @Input() serviciu: IServiciuToSaveDto;
  @Output() onSaveChanges: EventEmitter<IServiciuToSaveDto> = new EventEmitter<IServiciuToSaveDto>();

  serviciuForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.serviciuForm = this.fb.group({
      cod: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(3), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
      den: ['', [Validators.required, Validators.maxLength(50)]],
      um: ['', Validators.maxLength(3)]
    });

    if (this.serviciu != undefined) {
      this.serviciuForm.patchValue(this.serviciu);
    }
  }

  saveServiciu() {
    this.onSaveChanges.emit(this.serviciuForm.value);
  }

}