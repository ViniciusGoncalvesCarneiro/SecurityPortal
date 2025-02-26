import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IsoComponent } from './iso.component';

const routes: Routes = [
  {
    path: '',
    component: IsoComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class IsoRoutingModule { }
