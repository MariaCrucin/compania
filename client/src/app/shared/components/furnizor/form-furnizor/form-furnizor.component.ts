import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IFurnizorDto } from '../../../models/furnizor';


@Component({
  selector: 'app-form-furnizor',
  templateUrl: './form-furnizor.component.html',
  styleUrls: ['./form-furnizor.component.scss']
})
export class FormFurnizorComponent implements OnInit {

  @Input() errors: string[];

  furnizorForm: FormGroup;

  @Output() onSaveChanges: EventEmitter<IFurnizorDto> = new EventEmitter<IFurnizorDto>();
  @Output() onCancelAdd: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.furnizorForm = this.fb.group({
        atCif: ['', Validators.maxLength(2)],
        nrCif: ['', [Validators.required,  Validators.maxLength(13), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
        prefixDen: ['', Validators.maxLength(3)],
        den: ['', [Validators.required, Validators.maxLength(50)]]
    
    });
  }

  saveFurnizor() {
    this.onSaveChanges.emit(this.furnizorForm.value);
  }

  cancelFurnizor() {
    this.onCancelAdd.emit(true);
  }

}
