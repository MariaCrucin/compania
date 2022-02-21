import { IClient, IClientDto } from './../shared/models/client';
import { ClientiService } from './clienti.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clienti',
  templateUrl: './clienti.component.html',
  styleUrls: ['./clienti.component.scss']
})
export class ClientiComponent implements OnInit {

  firmaId: number;
  clienti: IClientDto[];

  constructor(private clientiService : ClientiService) { }

  ngOnInit(): void {
    this.firmaId = parseInt(localStorage.getItem('firmaId'));
    this.getClienti(this.firmaId);
  }

  getClienti(firmaID?: number) {
    this.clientiService.getClienti(this.firmaId).subscribe(response => {
      this.clienti = response;
    }, error => {
      console.log(error);
    });
  }

}
