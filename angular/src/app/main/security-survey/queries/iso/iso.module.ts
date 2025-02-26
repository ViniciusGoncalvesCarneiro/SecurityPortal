import { NgModule } from '@angular/core';
import { IsoRoutingModule } from './iso-routing.module';
import { IsoComponent } from './iso.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    IsoComponent
  ],
  imports: [
    AppSharedModule,
    IsoRoutingModule,
    AdminSharedModule
  ]
})

export class IsoModule { }
