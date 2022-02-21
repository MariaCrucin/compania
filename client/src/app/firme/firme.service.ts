import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IFirma } from '../shared/models/firma';

@Injectable({
  providedIn: 'root'
})
export class FirmeService {

  baseUrl = environment.apiUrl;
  private firmaSelectata = new BehaviorSubject<IFirma>(null);
  firma$ = this.firmaSelectata.asObservable();

  constructor(private http: HttpClient) { }

  getFirme() {
    return this.http.get<IFirma[]>(this.baseUrl + 'firme');
  }

  getFirma(id: number) {
    return this.http.get<IFirma>(this.baseUrl + 'firme/' + id);
  }

  seteazaFirma(firma: IFirma) {
    localStorage.setItem('firmaId', firma.id.toString());
    this.firmaSelectata.next(firma);
    //console.log(this.getCurrentFirmaValue());
  }

  getCurrentFirmaValue() {
    return this.firmaSelectata.value;
  }
}
