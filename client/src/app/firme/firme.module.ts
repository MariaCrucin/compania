import { FirmeRoutingModule } from './firme-routing.module';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FirmeComponent } from './firme.component';



@NgModule({
  declarations: [
    FirmeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FirmeRoutingModule
  ]
})
export class FirmeModule { }
