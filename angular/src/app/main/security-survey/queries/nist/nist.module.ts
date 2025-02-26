import { NgModule } from '@angular/core';
import { NistRoutingModule } from './nist-routing.module';
import { NistComponent } from './nist.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    NistComponent
  ],
  imports: [
    AppSharedModule,
    NistRoutingModule,
    AdminSharedModule
  ]
})

export class NistModule { }
