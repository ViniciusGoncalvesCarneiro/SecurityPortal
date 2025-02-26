import { NgModule } from '@angular/core';
import { CisToIsoRoutingModule } from './cis-to-iso-routing.module';
import { CisToIsoComponent } from './cis-to-iso.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    CisToIsoComponent
  ],
  imports: [
    AppSharedModule,
    CisToIsoRoutingModule,
    AdminSharedModule
  ]
})

export class CisToIsoModule { }
