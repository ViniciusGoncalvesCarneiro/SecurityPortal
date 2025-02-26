import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionRoutingModule } from './question-routing.module';
import { QuestionsComponent } from './questions.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';

@NgModule({
  declarations: [
    QuestionsComponent,
  ],
  imports: [
    AppSharedModule,
    QuestionRoutingModule,
    AdminSharedModule
  ],
})

export class QuestionModule { }
