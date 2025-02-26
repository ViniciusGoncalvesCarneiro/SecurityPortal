import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CisToMitreComponent } from './cis-to-mitre.component';

const routes: Routes = [
  {
    path: '',
    component: CisToMitreComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class CisToMitreRoutingModule { }
