import { NgModule } from '@angular/core';
import { PowerBiReportRoutingModule } from './power-bi-report-routing.module';
import { PowerBiReportsComponent } from './power-bi-reports.component';
import { CreateOrEditPowerBiReportModalComponent } from './create-or-edit-power-bi-report-modal.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { PowerBiReportViewComponent } from './power-bi-report-view.component';
//import { PowerBIEmbedModule } from 'powerbi-client-angular';

@NgModule({
  declarations: [
    PowerBiReportsComponent,
    CreateOrEditPowerBiReportModalComponent,
    PowerBiReportViewComponent
  ],
  imports: [
    AppSharedModule,
    PowerBiReportRoutingModule,
    AdminSharedModule
    //,PowerBIEmbedModule
  ]
})

export class PowerBiReportModule { }
