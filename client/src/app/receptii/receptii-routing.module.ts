import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceptiiComponent } from './receptii.component';
import { CreateReceptieComponent } from './create-receptie/create-receptie.component';
import { CreateFurnizorComponent } from './create-furnizor/create-furnizor.component';
import { EditReceptieComponent } from './edit-receptie/edit-receptie.component';


const routes: Routes = [
  {path:'', component: ReceptiiComponent, children: [
    {path:'new', component: CreateReceptieComponent, children: [
      {path: 'furnizor', component: CreateFurnizorComponent}
    ]},
    {path:':id', component: EditReceptieComponent}

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
export class ReceptiiRoutingModule { }
