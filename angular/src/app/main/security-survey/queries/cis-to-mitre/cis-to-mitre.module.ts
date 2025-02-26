import { NgModule } from '@angular/core';
import { CisToMitreRoutingModule } from './cis-to-mitre-routing.module';
import { CisToMitreComponent } from './cis-to-mitre.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    CisToMitreComponent
  ],
  imports: [
    AppSharedModule,
    CisToMitreRoutingModule,
    AdminSharedModule
  ]
})

export class CisToMitreModule { }
