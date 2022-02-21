import { BehaviorSubject } from 'rxjs';
import { ReceptieParams, IPaginationReceptie, IReceptieDto, IReceptieDtoToSave } from './../shared/models/receptie';
import { IUm } from './../shared/models/um';
import { FurnizoriService } from './../shared/components/furnizor/furnizori.service';
import { FurnizoriParams } from './../shared/models/furnizor';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ITipDoc } from '../shared/models/tipDoc';
import { IFirma } from '../shared/models/firma';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReceptiiService {
  baseUrl = environment.apiUrl;
  furnizoriParams = new FurnizoriParams();
  
  private modificareReceptii = new BehaviorSubject<boolean>(null);
  modificareReceptii$ = this.modificareReceptii.asObservable();

  constructor(private http: HttpClient, private furnizoriService: FurnizoriService) { }

  getFurnizori(beginDen: string) {
    
    this.furnizoriParams.searchDen = beginDen;

    return this.furnizoriService.getFurnizori(this.furnizoriParams);
  }

  

  getTipuriDoc() {
    return this.http.get<ITipDoc[]>(this.baseUrl + 'tipuriDoc');
  }

  getUm() {
    return this.http.get<IUm[]>(this.baseUrl + 'unitati');
  }

  getFirma(id: number) {
    return this.http.get<IFirma>(this.baseUrl + 'firme/' + id);
  }

  getNextNrNir() {
    return this.http.get<number>(this.baseUrl + 'receptii/nextnir');
  }

  createReceptie(receptie: IReceptieDtoToSave) {
    return this.http.post(this.baseUrl + 'receptii', receptie)
      .pipe(
        map(() => {
          this.modificareReceptii.next(true);
        })
      );
  }

  updateReceptie(id: number, receptie: IReceptieDtoToSave) {
    return this.http.put(this.baseUrl + 'receptii/' + id, receptie)
      .pipe(
        map(() => {
          this.modificareReceptii.next(true);
        })
      );
  }

  getReceptii(receptieParams: ReceptieParams) {
    let params = new HttpParams();

    params = params.append('pageIndex', receptieParams.pageIndex.toString());
    params = params.append('pageSize', receptieParams.pageSize.toString());

    if (receptieParams.furnizorId) {
      params = params.append('furnizorId', receptieParams.furnizorId.toString());
    }

    if (receptieParams.nrDoc) {
      params = params.append('nrDoc', receptieParams.nrDoc);
    }

    return this.http.get<IPaginationReceptie>(this.baseUrl + 'receptii', { params })
  }

  deleteReceptie(id: number) {
    return this.http.delete(this.baseUrl + 'receptii/' + id)
      .pipe(
        map(() => {
          this.modificareReceptii.next(true);
        })
      );
  }

  getReceptie(id: number) {
    return this.http.get<IReceptieDto>(this.baseUrl + 'receptii/' + id);
  }

}
