import { ClientiRoutingModule } from './clienti-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientiComponent } from './clienti.component';



@NgModule({
  declarations: [
    ClientiComponent
  ],
  imports: [
    CommonModule,
    ClientiRoutingModule
  ]
})
export class ClientiModule { }
