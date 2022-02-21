import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TarifeComponent } from './tarife.component';
import { TarifeRoutingModule } from './tarife-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CreateTarifComponent } from './create-tarif/create-tarif.component';
import { FormTarifComponent } from './form-tarif/form-tarif.component';
import { EditTarifComponent } from './edit-tarif/edit-tarif.component';



@NgModule({
  declarations: [
    TarifeComponent,
    CreateTarifComponent,
    FormTarifComponent,
    EditTarifComponent
  ],
  imports: [
    CommonModule,
    TarifeRoutingModule,
    SharedModule
  ]
})
export class TarifeModule { }
