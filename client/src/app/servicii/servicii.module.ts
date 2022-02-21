import { ServiciiRoutingModule } from './servicii-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServiciiComponent } from './servicii.component';
import { CreateServiciuComponent } from './create-serviciu/create-serviciu.component';
import { FormServiciuComponent } from './form-serviciu/form-serviciu.component';
import { SharedModule } from '../shared/shared.module';
import { EditServiciuComponent } from './edit-serviciu/edit-serviciu.component';



@NgModule({
  declarations: [
    ServiciiComponent,
    CreateServiciuComponent,
    FormServiciuComponent,
    EditServiciuComponent
  ],
  imports: [
    CommonModule,
    ServiciiRoutingModule,
    SharedModule
  ]
})
export class ServiciiModule { }
