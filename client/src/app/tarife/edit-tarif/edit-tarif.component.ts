import { ITarifToSaveDto } from './../../shared/models/tarif';
import { ActivatedRoute, Router } from '@angular/router';
import { TarifeService } from './../tarife.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITarif } from 'src/app/shared/models/tarif';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-tarif',
  templateUrl: './edit-tarif.component.html',
  styleUrls: ['./edit-tarif.component.scss']
})
export class EditTarifComponent implements OnInit, OnDestroy {

  tarif: ITarif;
  errors: string[];
  sub = new Subscription();

  constructor(private tarifeService: TarifeService, private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.loadTarif();
  }

  loadTarif() {
    this.sub.add(
      this.activatedRoute.params.subscribe(params => {
        this.tarifeService.getTarif(params.id).subscribe(tarif => {
          this.tarif = tarif;
        })
      })
    );
  }

  saveChanges(tarifDto: ITarifToSaveDto) {
    this.tarifeService.upadateTarif(this.tarif.id, tarifDto).subscribe(() => {
      this.toastr.success('Tariful a fost modificat !');
      this.router.navigate(['/tarife']);
    }, error => {
      this.errors = error.errors;
    })
  }

}
