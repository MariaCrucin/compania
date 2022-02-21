import { MagazineService } from './../magazine.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMagazinDto } from 'src/app/shared/models/magazin';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-magazin',
  templateUrl: './create-magazin.component.html',
  styleUrls: ['./create-magazin.component.scss']
})
export class CreateMagazinComponent implements OnInit {

  clientId: number;
  errors: string[];

  constructor(private magazineService: MagazineService, private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getClientId();
 }

  getClientId() {
    this.clientId = +this.activatedRoute.snapshot.paramMap.get('idClient');
  }

  saveChanges(magazinDto: IMagazinDto) {
    console.log(magazinDto);

    this.magazineService.createMagazin(magazinDto).subscribe(() => {
      this.toastr.success('Magazinul a fost salvat !');
      this.router.navigate(['/magazine']);
      // this.router.navigate(['../'], {relativeTo: this.route});
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })

  }

}