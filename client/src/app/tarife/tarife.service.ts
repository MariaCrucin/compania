import { map } from 'rxjs/operators';
import { ITarif, ITarifToSaveDto } from './../shared/models/tarif';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TarifeService {
  baseUrl = environment.apiUrl + 'tarife';

  private modificareTarife = new BehaviorSubject<boolean>(null);
  modificareTarife$ = this.modificareTarife.asObservable();

  constructor(private http: HttpClient) { }

  getTarife(clientId?: number) {
    let params = new HttpParams();

    if (clientId && clientId !== 0) {
      params = params.append('clientId', clientId.toString());
    }

    return this.http.get<ITarif[]>(this.baseUrl, { params });
  }

  createTarif(tarifDto: ITarifToSaveDto) {
    return this.http.post(this.baseUrl, tarifDto)
      .pipe(
        map(() => {
          this.modificareTarife.next(true);
        })
      );
  }

  upadateTarif(id: number, tarifDto: ITarifToSaveDto) {
    return this.http.put(this.baseUrl + '/' + id, tarifDto)
      .pipe(
        map(() => {
          this.modificareTarife.next(true);
        })
      );
  }

  getTarif(id: number) {
    return this.http.get<ITarif>(this.baseUrl + '/' + id);
  }

}
