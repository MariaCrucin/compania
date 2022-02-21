import { IMagazinDto } from './../../shared/models/magazin';
import { MagazineService } from './../magazine.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { IMagazin } from 'src/app/shared/models/magazin';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-magazin',
  templateUrl: './edit-magazin.component.html',
  styleUrls: ['./edit-magazin.component.scss']
})
export class EditMagazinComponent implements OnInit, OnDestroy {
  magazin: IMagazin;
  errors: string[];
  paramsSubscription: Subscription;

  constructor(private magazinService: MagazineService, private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.loadMagazin();
  }

  loadMagazin() {
    /* let id = +this.activatedRoute.snapshot.paramMap.get('id');
    this.magazinService.getMagazin(id).subscribe(magazin => {
      this.magazin = magazin;
    }, error => {
      console.log(error);
    }) */

    this.paramsSubscription = this.activatedRoute.params.subscribe(params => {
      this.magazinService.getMagazin(params.id).subscribe(magazin => {
        this.magazin = magazin;
      })
    });
  }

  saveChanges(magazinDto: IMagazinDto) {
    this.magazinService.updateMagazin(this.magazin.id, magazinDto).subscribe(() => {
      this.toastr.success('Magazinul a fost modificat !');
      this.router.navigate(['/magazine']);
      // this.router.navigate(['../'], {relativeTo: this.route});
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })
  }

}
