import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CisToIsoComponent } from './cis-to-iso.component';

const routes: Routes = [
  {
    path: '',
    component: CisToIsoComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class CisToIsoRoutingModule { }
