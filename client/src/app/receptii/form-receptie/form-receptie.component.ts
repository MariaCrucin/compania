import { IReceptieDto, IReceptieDtoToSave } from './../../shared/models/receptie';
import { IFirma } from './../../shared/models/firma';
import { IUm } from './../../shared/models/um';
import { FurnizoriService } from './../../shared/components/furnizor/furnizori.service';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { ReceptiiService } from './../receptii.service';
import { IFurnizor } from './../../shared/models/furnizor';
import { AfterViewChecked, ChangeDetectorRef, Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';

import { noop, Observable, Observer, of, Subscription } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';

import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ITipDoc } from 'src/app/shared/models/tipDoc';
import { environment } from 'src/environments/environment';import { FuncsService } from 'src/app/shared/services/funcs.service';
import { DatePipe } from '@angular/common';
 
@Component({
  selector: 'app-form-receptie',
  templateUrl: './form-receptie.component.html',
  styleUrls: ['./form-receptie.component.scss']
})
export class FormReceptieComponent implements OnInit, OnDestroy, AfterViewChecked {

  @Input() receptie: IReceptieDto;
  @Input() errors: string[];
  @Output() onSaveChanges: EventEmitter<IReceptieDtoToSave> = new EventEmitter<IReceptieDtoToSave>();

  nirForm: FormGroup;
  sub = new Subscription();

  suggestions$?: Observable<IFurnizor[]>;
  errorMessage?: string;
  selectedOption: IFurnizor;

  tipuriDoc: ITipDoc[];
  unitati: IUm[];
  firma: IFirma;

  nrPozDoc = 0;
  firmaId: number;
 
  constructor(private fb: FormBuilder, private receptiiService: ReceptiiService, private furnizoriService: FurnizoriService, 
    private changeDetectorRef: ChangeDetectorRef, private funcs: FuncsService, private datepipe: DatePipe) {}
  
  ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
 
  ngOnInit(): void {

    if (this.receptie != undefined) {
      this.firmaId = this.receptie.firmaId;
    } else {
      this.firmaId = parseInt(localStorage.getItem('firmaId'));
      this.getNextNrNir();
    }
  
    this.initializeForm();
    
    this.getTipuriDoc();

    this.getUm();

    this.getFirma();

    this.sub.add(
      this.furnizoriService.furnizor$.subscribe((furnizor: IFurnizor) => {
        if (furnizor != null) {
          this.nirForm.get('search').setValue(furnizor.prefixDen.trim()+' '+furnizor.den);
          this.nirForm.get('furnizorId').setValue(furnizor.id);
        }
      })
    );

    this.sub.add(
      this.materiale().valueChanges.subscribe(value => {
        this.nirForm.get('bazaAch').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.bazaAch || 0, 0)));
        this.nirForm.get('tvaAch').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.tvaAch || 0, 0)));
        this.nirForm.get('valAch').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.valAch || 0, 0)));
        this.nirForm.get('baza').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.baza || 0, 0)));
        this.nirForm.get('tva').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.tva || 0, 0)));
        this.nirForm.get('val').setValue(this.funcs.roundTo2(value.reduce((sum, item) => sum += item.val || 0, 0)));
      })
    )

    this.suggestions$ = new Observable((observer: Observer<string | undefined>) => {
      observer.next(this.nirForm.get('search').value);
    }).pipe(
      switchMap((query: string) => {
        if (query) {
          return this.receptiiService.getFurnizori(query)
          .pipe(
            map((data: IFurnizor[]) => data || []),
            tap(() => noop, err => {
              // in case of http error
              this.errorMessage = err && err.message || 'Something goes wrong';
            })
          );
        }
 
        return of([]);
      })
    )
  }
  
  getTipuriDoc() {
    this.receptiiService.getTipuriDoc().subscribe(response => { 
      this.tipuriDoc = response;
    })
  }

  getUm() {
    this.receptiiService.getUm().subscribe(response => {
      this.unitati = response; 
    })
  }

  getFirma() {
    this.receptiiService.getFirma(this.firmaId).subscribe(response => {
      this.firma = response;
    })
  }

  initializeForm() {
      this.nirForm = this.fb.group({
        firmaId: [this.firmaId, [Validators.required, Validators.min(1)]],
        search: '',
        furnizorId: [null, [Validators.required, Validators.min(1)]],
        tipDocumentId: [null, [Validators.required, Validators.min(1)]],
        nrDoc: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
        dataDoc: [new Date(), Validators.required],
        obs: ['', Validators.maxLength(10)],
        adaosProc: environment.adaosProc,
        nrNir: [null, Validators.min(1)],
        dataNir: [new Date(), Validators.required],
        bazaAch: 0,
        tvaAch: 0,
        valAch: 0,
        baza: 0,
        tva: 0,
        val: 0,
        materiale: this.fb.array([])
        // materiale: this.fb.array(this.receptie.materiale.map(m => this.fb.group(m)));
      });

      if (this.receptie != undefined) {
        this.nirForm.patchValue(this.receptie);

        //this.nirForm.get('dataNir').setValue(this.datepipe.transform(this.receptie.dataNir, 'dd.MM.yyyy'));
        //this.nirForm.get('dataDoc').setValue(this.datepipe.transform(this.receptie.dataDoc, 'dd.MM.yyyy'));
        this.nirForm.get('dataNir').setValue(new Date(this.receptie.dataNir));
        this.nirForm.get('dataDoc').setValue(new Date(this.receptie.dataDoc));
        this.nirForm.get('search').setValue(this.receptie.furnizor);

        this.receptie.materiale.forEach(m => {
          this.materiale().push(this.fb.group(m));
        });

        this.nrPozDoc = this.receptie.materiale.length;
      }
  }

  getNextNrNir() {
    this.receptiiService.getNextNrNir().subscribe(response => {
      this.nirForm.get('nrNir').setValue(response);
    })
  }

  onSelect(event: TypeaheadMatch) {
    this.selectedOption = event.item;
    this.nirForm.get('search').setValue(this.selectedOption.prefixDen.trim()+' '+this.selectedOption.den);
    this.nirForm.get('furnizorId').setValue(this.selectedOption.id);
    // this.nirForm.controls.furnizorId.setValue(this.nirForm.controls.furnizorId.value);
  }

  onLostFocus() {
    this.nirForm.get('furnizorId').setValue(null);
  }

  materiale(): FormArray {
    return this.nirForm.get('materiale') as FormArray;
  }

  newMaterial(): FormGroup {
    return this.fb.group({
      nrPozDoc: [null, Validators.required],
      den: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      cant: [null, Validators.required],
      um: ['BUC', Validators.required],
      cotaTvaAch: [null, Validators.required],
      pretAch: [null, Validators.required],
      bazaAch: [null, Validators.required],
      tvaAch: [null, Validators.required],
      valAch: [null, Validators.required],
      cotaTva: [null, Validators.required],
      adaosProc: [null, Validators.required],
      pret: [null, Validators.required],
      baza: [null, Validators.required],
      tva: [null, Validators.required],
      val: [null, Validators.required],
      cantUtilizata: 0,
      cantRamasa:0
    });
  }

  addMaterial() {
    var itemToAdd = this.newMaterial();

    this.nrPozDoc+=1;
    itemToAdd.get('nrPozDoc').setValue(this.nrPozDoc);
    itemToAdd.get('cotaTvaAch').setValue(environment.cotaTva);
    itemToAdd.get('cotaTva').setValue(environment.cotaTva);
    itemToAdd.get('adaosProc').setValue(this.nirForm.get('adaosProc').value);

    this.materiale().push(itemToAdd);
  }

  removeMaterial(i: number) {
    this.materiale().removeAt(i);
  } 
  
  onChangeNrPozDoc(valoare: number, poz: number) {
    if (this.nrPozDoc < valoare) {
      this.nrPozDoc = valoare;
    }
  }

  getItemFromArray(i: number) {
    return this.materiale().at(i);
  }

  getCant(i: number) {
    return this.getItemFromArray(i).get('cant').value;
  }

  getPretAch(i: number) {
    return this.getItemFromArray(i).get('pretAch').value;
  }

  getCotaTvaAch(i: number) {
    return this.getItemFromArray(i).get('cotaTvaAch').value;
  }
  
  getBazaAch(i: number) {
    return this.getItemFromArray(i).get('bazaAch').value;
  }

  getTvaAch(i: number) {
    return this.getItemFromArray(i).get('tvaAch').value;
  }

  getValAch(i: number) {
    return this.getItemFromArray(i).get('valAch').value;
  }

  getAdaosProc(i: number) {
    return this.getItemFromArray(i).get('adaosProc').value;
  }

  getPret(i: number) {
    return this.getItemFromArray(i).get('pret').value;
  }

  getCotaTva(i: number) {
    return this.getItemFromArray(i).get('cotaTva').value;
  }

  getBaza(i: number) {
    return this.getItemFromArray(i).get('baza').value;
  }

  getTva(i: number) {
    return this.getItemFromArray(i).get('tva').value;
  }

  getCantUtilizata(i: number) {
    return this.getItemFromArray(i).get('cantUtilizata').value;
  }

  setValuesAtVanzare(i: number) {
    this.getItemFromArray(i).get('pret').setValue(this.funcs.calcPretVanz(this.getPretAch(i), this.getAdaosProc(i)));
    this.getItemFromArray(i).get('baza').setValue(this.funcs.calcBaza(this.getPret(i), this.getCant(i)));
    this.getItemFromArray(i).get('tva').setValue(this.funcs.calcTva(this.getBaza(i),this.getCotaTva(i)));
    this.getItemFromArray(i).get('val').setValue(this.funcs.calcVal(this.getBaza(i), this.getTva(i)));
  }


  onChangeAdaosProc(i: number) {
    this.setValuesAtVanzare(i);
  }

  onChangeBazaAch(i: number) {
    if (this.getCant(i) && this.getCant(i) != 0) {
      this.getItemFromArray(i).get('pretAch').setValue(this.funcs.calcPret(this.getBazaAch(i), this.getCant(i)));
    }
    this.getItemFromArray(i).get('tvaAch').setValue(this.funcs.calcTva(this.getBazaAch(i), this.getCotaTvaAch(i)));
    this.getItemFromArray(i).get('valAch').setValue(this.funcs.calcVal(this.getBazaAch(i), this.getTvaAch(i)));
    this.setValuesAtVanzare(i);
  }

  onChangeValAch(i: number) {
    this.getItemFromArray(i).get('bazaAch').setValue(this.funcs.calcBazaFromVal(this.getValAch(i), this.getCotaTvaAch(i)));
    if (this.getCant(i) && this.getCant(i) != 0) {
      this.getItemFromArray(i).get('pretAch').setValue(this.funcs.calcPret(this.getBazaAch(i), this.getCant(i)));
    }
    this.getItemFromArray(i).get('tvaAch').setValue(this.funcs.calcTvaAsDif(this.getValAch(i), this.getBazaAch(i)));
    this.setValuesAtVanzare(i);
  } 

  onChangeCant(i: number) {
    if (this.getCant(i) && this.getCant(i) != 0 && this.getBazaAch(i)) {
      this.getItemFromArray(i).get('pretAch').setValue(this.funcs.calcPret(this.getBazaAch(i), this.getCant(i)));
    }
    this.getItemFromArray(i).get('cantRamasa').setValue(this.funcs.roundTo4(this.getCant(i)-this.getCantUtilizata(i)));
    this.setValuesAtVanzare(i);
  }

  saveReceptie() {
    this.onSaveChanges.emit(this.nirForm.value);
  }

}
