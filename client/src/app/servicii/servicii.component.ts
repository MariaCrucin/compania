import { IServiciu } from './../shared/models/tarif';
import { ServiciiService } from './servicii.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-servicii',
  templateUrl: './servicii.component.html',
  styleUrls: ['./servicii.component.scss']
})
export class ServiciiComponent implements OnInit, OnDestroy {
  cod='';

  servicii: IServiciu[];
  totalCount = 0;

  modificari: boolean;
  sub: Subscription;

  constructor(private serviciiService: ServiciiService) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.getServicii();
    
    this.sub = this.serviciiService.modificareServicii$.subscribe(modificari => {
      this.modificari = modificari;
      if (this.modificari) {
        this.getServicii();
      }
    })
  }

  getServicii() {
    this.serviciiService.getServicii(this.cod).subscribe(response => {
      this.servicii = response;
      this.totalCount = this.servicii.length;
    })
  }

  onSearch() {
    this.getServicii();
  }

}
