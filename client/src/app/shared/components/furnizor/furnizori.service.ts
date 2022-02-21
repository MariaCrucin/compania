import { IFurnizor, IFurnizorDto, FurnizoriParams } from './../../models/furnizor';
import { BehaviorSubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FurnizoriService {

baseUrl = environment.apiUrl + 'furnizori';

// private furnizorAdded = new BehaviorSubject<IFurnizor>(null);
private furnizorAdded = new Subject<IFurnizor>();
furnizor$ = this.furnizorAdded.asObservable();

constructor(private http: HttpClient) { }

createFurnizor(furnizorDto: IFurnizorDto) {
  return this.http.post(this.baseUrl, furnizorDto)
  .pipe(
    map((response: IFurnizor) => {
      this.furnizorAdded.next(response);
    }, error => {
      console.log(error);
    })
  )
}

getFurnizori(furnizoriParams: FurnizoriParams) {
    
  let params = new HttpParams();

  if (furnizoriParams.searchDen) {
    params = params.append('searchDen', furnizoriParams.searchDen);
  }

  if (furnizoriParams.nrCif) {
    params = params.append('nrCif', furnizoriParams.nrCif);
  }

  return this.http.get<IFurnizor[]>(this.baseUrl, {params})
}

}
