import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  // {path: '', component: },
  {path: '', component: HomeComponent},
  {path: 'test-errors', component: TestErrorComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'firme', loadChildren: () => import('./firme/firme.module').then(mod => mod.FirmeModule)},
  {path: 'clienti', loadChildren: () => import('./clienti/clienti.module').then(mod => mod.ClientiModule)},
  {path: 'magazine', loadChildren: () => import('./magazine/magazine.module').then(mod => mod.MagazineModule)},
  {path: 'receptii', loadChildren: () => import('./receptii/receptii.module').then(mod => mod.ReceptiiModule)},
  {path: 'servicii', loadChildren: () => import ('./servicii/servicii.module').then(mod => mod.ServiciiModule)},
  {path: 'tarife',loadChildren: () => import('./tarife/tarife.module').then(mod => mod.TarifeModule)},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
