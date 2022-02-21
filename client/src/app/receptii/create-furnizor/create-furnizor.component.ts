import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FurnizoriService } from 'src/app/shared/components/furnizor/furnizori.service';
import { IFurnizorDto } from 'src/app/shared/models/furnizor';

@Component({
  selector: 'app-create-furnizor',
  templateUrl: './create-furnizor.component.html',
  styleUrls: ['./create-furnizor.component.scss']
})
export class CreateFurnizorComponent implements OnInit {

  errors: string[];

  constructor(private furnizoriService: FurnizoriService, private router:Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  saveChanges(furnizorDto: IFurnizorDto) {
    this.furnizoriService.createFurnizor(furnizorDto).subscribe(() => {
      this.toastr.success('Furnizorul a fost salvat !');
      this.router.navigate(['/receptii/new']);
    }, error => {
      this.errors = error.errors;
      console.clear();
      console.log(this.errors);
    })
  }

  cancelAction(anulare: boolean) {
    this.router.navigate(['/receptii/new']);
  }

}
