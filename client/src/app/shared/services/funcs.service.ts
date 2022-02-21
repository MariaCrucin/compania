import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FuncsService {

  constructor() { }

  roundTo2(num: number) {    
    return Math.round((num + Number.EPSILON) * 100) / 100;
  }

  roundTo4(num: number) {    
    return Math.round((num + Number.EPSILON) * 10000) / 10000;
  }

  calcPret(baza: number, cant: number) : number {
    if (cant != 0 ) {
      return this.roundTo4((baza || 0) /cant);
    } else {
      return null;
    }
    
  }

  calcPretVanz(pretAch: number, adaosProc: number) {
    return this.roundTo4((pretAch || 0) + this.roundTo4((pretAch || 0) * (adaosProc || 0) / 100));
  }

  calcBaza(pret: number, cant: number) : number {
    return this.roundTo2((pret || 0) * (cant || 0));
  }

  calcTva(baza: number, cotaTva: number) : number {
    return this.roundTo2((baza || 0) * (cotaTva || 0) / 100);
  }

  calcTvaAsDif(val: number, baza: number) : number {
    return this.roundTo2((val || 0) - (baza || 0));
  }

 calcVal(baza: number, tva: number) : number {
    return this.roundTo2((baza || 0) + (tva || 0));
 }
  
 calcBazaFromVal(val: number, cotaTva: number) : number {
    return this.roundTo2((val || 0 ) * 100 / (100 + (cotaTva || 0)));
 }
}
