import { IFirma } from './../shared/models/firma';
import { FirmeService } from './firme.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-firme',
  templateUrl: './firme.component.html',
  styleUrls: ['./firme.component.scss']
})
export class FirmeComponent implements OnInit {
  firme: IFirma[];

  constructor(private firmeService: FirmeService) { }

  ngOnInit(): void {
    this.firmeService.getFirme().subscribe(response => {
      this.firme = response;
    }, error => {
      console.log(error);
    });
  }

  selecteaza(firma: IFirma){
    this.firmeService.seteazaFirma(firma);
  }

}
