import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MitreComponent } from './mitre.component';

const routes: Routes = [
  {
    path: '',
    component: MitreComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MitreRoutingModule { }
