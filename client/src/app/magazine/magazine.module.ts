import { SharedModule } from './../shared/shared.module';
import { MagazineRoutingModule } from './magazine-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MagazineComponent } from './magazine.component';
import { CreateMagazinComponent } from './create-magazin/create-magazin.component';
import { EditMagazinComponent } from './edit-magazin/edit-magazin.component';
import { FormMagazinComponent } from './form-magazin/form-magazin.component';
import { ImportMagazinComponent } from './import-magazin/import-magazin.component';



@NgModule({
  declarations: [
    MagazineComponent,
    CreateMagazinComponent,
    EditMagazinComponent,
    FormMagazinComponent,
    ImportMagazinComponent
  ],
  imports: [
    CommonModule,
    MagazineRoutingModule,
    SharedModule
  ]
})
export class MagazineModule { }
