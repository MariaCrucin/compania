import { ITarif, ITarifToSaveDto } from './../../shared/models/tarif';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TarifeService } from '../tarife.service';

@Component({
  selector: 'app-create-tarif',
  templateUrl: './create-tarif.component.html',
  styleUrls: ['./create-tarif.component.scss']
})
export class CreateTarifComponent implements OnInit {

  errors: string[];
  clientId: number;

  constructor(private tarifeService: TarifeService, private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getClientId();
  }

  getClientId() {
    this.clientId = +this.activatedRoute.snapshot.paramMap.get('clientId');
  }

  saveChanges(tarif: ITarifToSaveDto) {
    tarif.clientId = this.clientId;
    
    this.tarifeService.createTarif(tarif).subscribe(() => {
      this.toastr.success('Tariful a fost salvat !');
      this.router.navigate(['/tarife']);
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })
  }

}
