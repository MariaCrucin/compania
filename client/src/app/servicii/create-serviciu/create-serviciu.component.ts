import { IServiciuToSaveDto } from './../../shared/models/tarif';
import { ToastrService } from 'ngx-toastr';
import { ServiciiService } from './../servicii.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-serviciu',
  templateUrl: './create-serviciu.component.html',
  styleUrls: ['./create-serviciu.component.scss']
})
export class CreateServiciuComponent implements OnInit {

  errors: string[];

  constructor(private serviciiService: ServiciiService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  saveChanges(serviciuDto: IServiciuToSaveDto) {
    this.serviciiService.createServiciu(serviciuDto).subscribe(() => {
      this.toastr.success('Serviciul a fost salvat !');
      this.router.navigate(['/servicii']);
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })
  }

}
