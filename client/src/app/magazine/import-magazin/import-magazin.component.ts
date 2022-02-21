import { MagazineService } from './../magazine.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-import-magazin',
  templateUrl: './import-magazin.component.html',
  styleUrls: ['./import-magazin.component.scss']
})
export class ImportMagazinComponent implements OnInit {

  clientId: number;
  form: FormGroup;
  year = new Date().getFullYear();

  constructor(private activatedRoute: ActivatedRoute, private magazineService: MagazineService, private fb: FormBuilder, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.getClientId();
    this.initializeForm();
  }
 
   getClientId() {
     this.clientId = +this.activatedRoute.snapshot.paramMap.get('idClient');
   }

   initializeForm() {
    this.form = this.fb.group({
      clientId: 0,
      file: ''
    });

    if (this.clientId !== undefined) {
     this.form.get('clientId').setValue(this.clientId);
    }
  }

  change(event) {
    if (event.target.files.length > 0)
      var fileAles: File = event.target.files[0];
      this.form.get('file').setValue(fileAles);
      
      this.magazineService.importMagazine(this.form.value).subscribe(() => {
        this.toastr.success('CC au fost importate !');
        this.router.navigate(['/magazine']);
      }, error => {
        console.log(error);
      })
  }

}
