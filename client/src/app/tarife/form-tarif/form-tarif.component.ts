import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { map, tap } from 'rxjs/operators';
import { ServiciiSharedService } from './../../shared/services/servicii-shared.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IServiciu, ITarif, ITarifToSaveDto } from './../../shared/models/tarif';
import { Component, EventEmitter, Input, OnInit, Output, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-form-tarif',
  templateUrl: './form-tarif.component.html',
  styleUrls: ['./form-tarif.component.scss']
})
export class FormTarifComponent implements OnInit, OnDestroy {
  
  @Input() tarif: ITarif;
  @Input() errors: string[];
  @Output() onSaveChanges: EventEmitter<ITarifToSaveDto> = new EventEmitter<ITarifToSaveDto>();

  tarifForm: FormGroup;
  servicii: IServiciu[];
  //visibleServicii$: Observable<IServiciu[]>;
  visibleServicii: IServiciu[];
  den = '';
  um = '';
  selectedOption: IServiciu;

  sub = new Subscription();

  constructor(private fb: FormBuilder, private serviciiSharedService: ServiciiSharedService) {}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
   this.initializeForm();
  }

  initializeForm() {

    this.getServicii();
    
    this.tarifForm = this.fb.group({
      clientId: null,
      serviciuId: [null, Validators.required],
      pret: null,
      coefKm: null,
      procDisc: null,
      cod: ''
    });

    if (this.tarif != undefined) {
      this.tarifForm.patchValue(this.tarif);
      this.den = this.tarif.den;
      this.um = this.tarif.um;
    }

    // this.visibleServicii$ =  this.tarifForm.get('cod')?.valueChanges
    //   .pipe(
    //     tap(value => console.log(value)),
    //     map(value => this.servicii.filter(s => s.cod.startsWith(value)))
    //   )

    // map: la iesirea din el avem un nou observable: sirul de servicii filtrat
    // daca punem   tap(value => console.log(value))   dupa map, vom vedea sirul, nu cod.value

    this.sub.add(
      this.tarifForm.get('cod')?.valueChanges.subscribe(value => this.filterArray(value))
    );
    
  }

  getServicii(cod?: string) {
    this.serviciiSharedService.getServicii(cod).subscribe(response => {
      this.servicii = response;
      this.visibleServicii = response;
    })
  }

  onSelect(event: TypeaheadMatch) {
    this.selectedOption = event.item;
    this.tarifForm.get('serviciuId').setValue(this.selectedOption.id);
    this.den = this.selectedOption.den;
    this.um = this.selectedOption.um;
  }

  filterArray(term: string) {
    this.visibleServicii = this.servicii.filter(s => s.cod.startsWith(term));
  }

  saveTarif() {
    this.onSaveChanges.emit(this.tarifForm.value);
  }

}