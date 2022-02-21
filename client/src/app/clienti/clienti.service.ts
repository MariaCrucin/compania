import { ClientiSharedService } from './../shared/services/clienti-shared.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientiService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private clientiSharedService: ClientiSharedService) { }

  getClienti(firmaId?: number, beginDen?: string) {
    return this.clientiSharedService.getClienti(firmaId, beginDen);
  }
}
