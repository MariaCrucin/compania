import { ServiciiService } from './../servicii.service';
import { IServiciu, IServiciuToSaveDto } from './../../shared/models/tarif';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-serviciu',
  templateUrl: './edit-serviciu.component.html',
  styleUrls: ['./edit-serviciu.component.scss']
})
export class EditServiciuComponent implements OnInit, OnDestroy {

  serviciu: IServiciu;
  errors: string[];
  paramsSubscription: Subscription;

  constructor(private serviciiService: ServiciiService, private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.loadServiciu();
  }

  loadServiciu() {
    this.paramsSubscription = this.activatedRoute.params.subscribe(params => {
      this.serviciiService.getServiciu(params.id).subscribe(serviciu => {
        this.serviciu = serviciu;
      })
    });
  }

  saveChanges(serviciuDto: IServiciuToSaveDto) {
    this.serviciiService.updateServiciu(this.serviciu.id, serviciuDto).subscribe(() => {
      this.toastr.success('Serviciul a fost modificat !');
      this.router.navigate(['/servicii']);
    }, error => {
      console.log(error);
      this.errors = error.errors;
    });
  }

}
