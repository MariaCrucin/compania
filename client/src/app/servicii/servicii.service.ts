import { ServiciiSharedService } from './../shared/services/servicii-shared.service';
import { IServiciu, IServiciuToSaveDto } from './../shared/models/tarif';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ServiciiService {

  baseUrl = environment.apiUrl + 'servicii';

  private modificareServicii = new BehaviorSubject<boolean>(null);
  modificareServicii$ = this.modificareServicii.asObservable();

  constructor(private http: HttpClient, private serviciiSharedService: ServiciiSharedService) { }

  getServicii(cod?: string) {
    return this.serviciiSharedService.getServicii(cod);
  }
 
  getServiciu(id: number) {
    return this.http.get<IServiciu>(this.baseUrl + '/' + id);
  }

  createServiciu(serviciuDto: IServiciuToSaveDto) {
    return this.http.post(this.baseUrl, serviciuDto)
      .pipe(
        map(() => {
          this.modificareServicii.next(true);
        })
      );
  }

  updateServiciu(id: number, serviciuDto: IServiciuToSaveDto) {
    return this.http.put(this.baseUrl + '/' + id, serviciuDto)
    .pipe(
      map(() => {
        this.modificareServicii.next(true);
      })
    );
  }

}

