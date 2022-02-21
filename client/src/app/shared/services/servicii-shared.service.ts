import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IServiciu } from '../models/tarif';

@Injectable({
  providedIn: 'root'
})
export class ServiciiSharedService {
  
  baseUrl = environment.apiUrl + 'servicii';

  constructor(private http: HttpClient) { }

  getServicii(cod?: string) {
    let params = new HttpParams();

    if (cod) {
      params = params.append('cod', cod);
    }

    return this.http.get<IServiciu[]>(this.baseUrl, { params });
  }
}
