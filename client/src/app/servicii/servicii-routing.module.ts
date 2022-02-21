import { CreateServiciuComponent } from './create-serviciu/create-serviciu.component';
import { ServiciiComponent } from './servicii.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { EditServiciuComponent } from './edit-serviciu/edit-serviciu.component';

const routes: Routes = [
  {path: '', component: ServiciiComponent, children: [
    {path: 'new', component: CreateServiciuComponent},
    {path: ':id', component: EditServiciuComponent}
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
export class ServiciiRoutingModule { }
