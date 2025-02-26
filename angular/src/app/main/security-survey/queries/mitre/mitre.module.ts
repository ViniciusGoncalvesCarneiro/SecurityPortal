import { NgModule } from '@angular/core';
import { MitreRoutingModule } from './mitre-routing.module';
import { MitreComponent } from './mitre.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    MitreComponent
  ],
  imports: [
    AppSharedModule,
    MitreRoutingModule,
    AdminSharedModule
  ]
})

export class MitreModule { }
