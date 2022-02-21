import { PageParams } from './../shared/models/pageParams';
import { MagazinParams } from './../shared/models/magazinParams';
import { ClientiService } from './../clienti/clienti.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { IClient, IClientDto } from '../shared/models/client';
import { IMagazin } from '../shared/models/magazin';
import { MagazineService } from './magazine.service';
import { ThrowStmt } from '@angular/compiler';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-magazine',
  templateUrl: './magazine.component.html',
  styleUrls: ['./magazine.component.scss']
})
export class MagazineComponent implements OnInit, OnDestroy {

  firmaId: number;
  clienti: IClientDto[];
  magazinParams = new MagazinParams();
  totalCount: number;
  magazine: IMagazin[];
  sortOptions = [
    {name: 'Crescator dupa Numar', value: 'numar'},
    {name: 'Alfabetic dupa Denumire', value: 'den'},
  ];

  modificari: boolean;
  private sub : Subscription;

  year = new Date().getFullYear();

  constructor(private clientiService: ClientiService, private magazineService: MagazineService) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.firmaId = parseInt(localStorage.getItem('firmaId'));
    this.getClienti();

    this.sub = this.magazineService.modificareMagazine$.subscribe(modificari => {
      this.modificari = modificari;
      if (this.modificari) {
        this.getMagazine()
      }
    })
  }

  getClienti() {
    this.clientiService.getClienti(this.firmaId).subscribe(response => {
      this.clienti = response;
    }, error => {
      console.log(error);
    })
  }

  getMagazine() {
    this.magazineService.getMagazine(this.magazinParams).subscribe(response => {
      this.magazine = response.data;
      this.magazinParams.pageNumber = response.pageIndex;
      this.magazinParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
      
    })
  }

    onClientSelected(clientId: number) {
      this.magazinParams.clientId = clientId;
      this.magazinParams.pageNumber = 1;
      this.getMagazine();
    }
  
    onSortSelected(sort: string) {
      this.magazinParams.sort = sort;
      this.magazinParams.pageNumber = 1;
      this.getMagazine();
    }

    onSearch() {
      this.magazinParams.pageNumber = 1;
      this.getMagazine();
    }

    onReset() {
      this.magazinParams.searchDen = '';
      this.magazinParams.searchNr = null;
      this.magazinParams.pageNumber = 1;
      this.getMagazine();
    }

    onPageChanged(pageParams: PageParams) {
      if (this.magazinParams.pageNumber !== pageParams.pageNumber || this.magazinParams.pageSize !== pageParams.pageSize) {
        this.magazinParams.pageNumber = pageParams.pageNumber;
        this.magazinParams.pageSize = pageParams.pageSize;
        this.getMagazine();
      }
    }

}
