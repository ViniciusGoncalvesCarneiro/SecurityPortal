import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CisToNistComponent } from './cis-to-nist.component';

const routes: Routes = [
  {
    path: '',
    component: CisToNistComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class CisToNistRoutingModule { }
