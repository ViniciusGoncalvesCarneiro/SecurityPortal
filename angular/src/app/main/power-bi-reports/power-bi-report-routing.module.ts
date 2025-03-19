import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PowerBiReportsComponent } from './power-bi-reports.component';
import { PowerBiReportViewComponent } from './power-bi-report-view.component';

const routes: Routes = [
  {
    path: '',
    component: PowerBiReportsComponent,
    pathMatch: 'full',
  },

  {
    path: 'powerbireportview',
    component: PowerBiReportViewComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class PowerBiReportRoutingModule { }
