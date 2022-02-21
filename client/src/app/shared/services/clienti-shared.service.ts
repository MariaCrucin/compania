import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IClientDto } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientiSharedService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getClienti(firmaId?: number, beginDen?: string) {
    let params = new HttpParams();
    if (firmaId) {
      params = params.append('firmaId', firmaId.toString());
    }

    if (beginDen) {
      params = params.append('beginDen', beginDen);
    }

    return this.http.get<IClientDto[]>(this.baseUrl + 'clienti', { params });
  }
}
