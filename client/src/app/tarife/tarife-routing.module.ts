import { CreateTarifComponent } from './create-tarif/create-tarif.component';
import { TarifeComponent } from './tarife.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { EditTarifComponent } from './edit-tarif/edit-tarif.component';


const routes: Routes = [
  {path: '', component: TarifeComponent, children: [
    {path: 'new/:clientId', component: CreateTarifComponent},
    {path: ':id', component: EditTarifComponent}
  ]}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class TarifeRoutingModule { }
