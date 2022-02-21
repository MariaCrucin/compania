import { ITarif } from './../shared/models/tarif';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { TarifeService } from './tarife.service';
import { Subscription } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-tarife',
  templateUrl: './tarife.component.html',
  styleUrls: ['./tarife.component.scss']
})
export class TarifeComponent implements OnInit, OnDestroy {

  firmaId: number;
  clientId: number;
  tarife: ITarif[];

  modificari: boolean;
  private sub = new Subscription();

  constructor(private tarifeService: TarifeService) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.firmaId = parseInt(localStorage.getItem('firmaId'));

    this.sub.add(this.tarifeService.modificareTarife$.subscribe(modificari => {
      this.modificari = modificari;
      if (this.modificari) {
        this.getTarife();
      }
    }));
  }

  selectClient(clientId: number){
    this.clientId = clientId;
    this.getTarife();
  }

  getTarife() {
    this.tarifeService.getTarife(this.clientId).subscribe(response => {
      this.tarife  = response;
    })
  }

}
