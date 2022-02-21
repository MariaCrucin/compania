import { BehaviorSubject } from 'rxjs';
import { IPaginationMagazin } from './../shared/models/paginationMagazin';
import { IMagazinImportParams, MagazinParams } from './../shared/models/magazinParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMagazin, IMagazinDto } from '../shared/models/magazin';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MagazineService {

  baseUrl = environment.apiUrl + 'magazine';
  private modificareMagazine = new BehaviorSubject<boolean>(null);
  modificareMagazine$ = this.modificareMagazine.asObservable();

  constructor(private http: HttpClient) { }

  getMagazine(magazinParams: MagazinParams) {
    let params = new HttpParams();

    if (magazinParams.clientId !== 0) {
      params = params.append('clientId', magazinParams.clientId.toString());
    }

    if (magazinParams.searchDen) {
      params = params.append('searchDen', magazinParams.searchDen);
    }

    if (magazinParams.searchNr && magazinParams.searchNr !== 0) {
      params = params.append('searchNr', magazinParams.searchNr.toString());
    }

    params = params.append('sort', magazinParams.sort);
    params = params.append('pageIndex', magazinParams.pageNumber.toString());
    params = params.append('pageSize', magazinParams.pageSize.toString());

    return this.http.get<IPaginationMagazin>(this.baseUrl, { params });

  }

  getMagazin(id: number) {
    return this.http.get<IMagazin>(this.baseUrl + '/' + id);

    // return this.http.get<IMagazin>(`${this.baseUrl}/${id}`);

  }

  createMagazin(magazinDto: IMagazinDto) {
    return this.http.post(this.baseUrl, magazinDto)
      .pipe(
        map(() => {
          this.modificareMagazine.next(true);
        })
      );
  }

  updateMagazin(id: number, magazinDto: IMagazinDto) {
    return this.http.put(`${this.baseUrl}/${id}`, magazinDto)
     .pipe(
        map(() => {
          this.modificareMagazine.next(true);
        })
      );
  }

  importMagazine(importInfo: IMagazinImportParams) {
    const formData = this.buildFormData(importInfo);
    return this.http.post(this.baseUrl + '/import', formData)
    .pipe(
      map(() => {
        this.modificareMagazine.next(true);
      })
    );
  }

  private buildFormData(importInfo: IMagazinImportParams): FormData { 
    const formData = new FormData();

    formData.append('clientId', importInfo.clientId.toString());
    formData.append('file', importInfo.file);

    return formData;
  }
}