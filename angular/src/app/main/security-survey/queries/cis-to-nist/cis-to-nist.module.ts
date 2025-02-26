import { NgModule } from '@angular/core';
import { CisToNistRoutingModule } from './cis-to-nist-routing.module';
import { CisToNistComponent } from './cis-to-nist.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    CisToNistComponent
  ],
  imports: [
    AppSharedModule,
    CisToNistRoutingModule,
    AdminSharedModule
  ]
})

export class CisToNistModule { }
