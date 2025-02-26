import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NistComponent } from './nist.component';

const routes: Routes = [
  {
    path: '',
    component: NistComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class NistRoutingModule { }
