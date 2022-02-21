import { SharedModule } from './../shared/shared.module';
import { ReceptiiRoutingModule } from './receptii-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceptiiComponent } from './receptii.component';
import { CreateReceptieComponent } from './create-receptie/create-receptie.component';
import { FormReceptieComponent } from './form-receptie/form-receptie.component';
import { CreateFurnizorComponent } from './create-furnizor/create-furnizor.component';
import { EditReceptieComponent } from './edit-receptie/edit-receptie.component';

@NgModule({
  declarations: [
    ReceptiiComponent,
    CreateReceptieComponent,
    FormReceptieComponent,
    CreateFurnizorComponent,
    EditReceptieComponent,
  ],
  imports: [
    CommonModule,
    ReceptiiRoutingModule,
    SharedModule
  ]
})
export class ReceptiiModule { }
