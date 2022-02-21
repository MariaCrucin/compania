import { IReceptieDtoToSave } from './../../shared/models/receptie';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ReceptiiService } from './../receptii.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-receptie',
  templateUrl: './create-receptie.component.html',
  styleUrls: ['./create-receptie.component.scss']
})
export class CreateReceptieComponent implements OnInit {

  errors: string[];

  constructor(private receptiiService: ReceptiiService, private router: Router, private toastr: ToastrService) {}
 
  ngOnInit(): void {
  }

  saveChanges(receptie: IReceptieDtoToSave) {
    this.receptiiService.createReceptie(receptie).subscribe(() => {
      this.toastr.success('Receptia a fost salvata !');
      this.router.navigate(['/receptii']);
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })    
  }

}
