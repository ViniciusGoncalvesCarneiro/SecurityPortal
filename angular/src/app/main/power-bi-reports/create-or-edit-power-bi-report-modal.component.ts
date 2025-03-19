import { Component, EventEmitter, Injector, OnInit, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { ModalDirective } from '@node_modules/ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateOrEditPowerBIReportDto, PowerBIReportServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'createOrEditPowerBIReportModal',
  templateUrl: './create-or-edit-power-bi-report-modal.component.html'
})

export class CreateOrEditPowerBiReportModalComponent extends AppComponentBase implements OnInit {

  @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  powerBIReport: CreateOrEditPowerBIReportDto = new CreateOrEditPowerBIReportDto();

  active = false;
  saving = false;

  constructor(
    injector: Injector,
    private _powerBIReportsServiceProxy: PowerBIReportServiceProxy,
  ) {
    super(injector);
  }

  onShown(): void {
    document.getElementById('PowerBIReport_GroupId').focus();
  }

  show(powerBIReportId?: string): void {
    if (!powerBIReportId) {
      this.powerBIReport = new CreateOrEditPowerBIReportDto();
      this.powerBIReport.id = powerBIReportId;
      this.active = true;
      this.modal.show();
    } else {
      this._powerBIReportsServiceProxy.getPowerBIReportForEdit(powerBIReportId)
        .subscribe((result) => {
          this.powerBIReport = result.powerBIReport;
          this.active = true;
          this.modal.show();
        });
    }
  }

  save(): void {

    this.saving = true;
    this._powerBIReportsServiceProxy
      .createOrEdit(this.powerBIReport)
      .pipe(
        finalize(() => {
          this.saving = false;
        }),
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  ngOnInit(): void {
  }

}
