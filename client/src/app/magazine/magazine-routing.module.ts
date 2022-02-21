import { ImportMagazinComponent } from './import-magazin/import-magazin.component';
import { EditMagazinComponent } from './edit-magazin/edit-magazin.component';
import { CreateMagazinComponent } from './create-magazin/create-magazin.component';
import { MagazineComponent } from './magazine.component';
import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'', component: MagazineComponent, children: [
    {path:'new/:idClient', component: CreateMagazinComponent},
    {path: 'import/:idClient', component: ImportMagazinComponent},
    {path:':id', component: EditMagazinComponent}
  ]}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MagazineRoutingModule { }
