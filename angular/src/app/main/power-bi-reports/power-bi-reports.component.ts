import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateOrEditPowerBiReportModalComponent } from './create-or-edit-power-bi-report-modal.component';
import { PowerBIReportDto, PowerBIReportServiceProxy } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';

@Component({
  templateUrl: './power-bi-reports.component.html',
  animations: [appModuleAnimation()],
  encapsulation: ViewEncapsulation.None
})

export class PowerBiReportsComponent extends AppComponentBase implements OnInit {

  @ViewChild('createOrEditPowerBIReportModal', { static: true }) createOrEditPowerBIReportModal: CreateOrEditPowerBiReportModalComponent;

  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;

  filterText = '';

  constructor(
    injector: Injector,
    private _powerBIReportsServiceProxy: PowerBIReportServiceProxy,

  ) {
    super(injector);
  }

  getPowerBIReports(event?: LazyLoadEvent) {

    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      if (this.primengTableHelper.records && this.primengTableHelper.records.length > 0) {
        return;
      }
    }

    this.primengTableHelper.showLoadingIndicator();

    this._powerBIReportsServiceProxy
      .getAll(
        this.filterText,
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getSkipCount(this.paginator, event),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
      )
      .subscribe((result) => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
      });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  createPowerBIReport(): void {
    this.createOrEditPowerBIReportModal.show();
  }

  deletePowerBIReport(powerBIReport: PowerBIReportDto): void {

    this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
      if (isConfirmed) {
        this._powerBIReportsServiceProxy.delete(powerBIReport.id).subscribe(() => {
          this.reloadPage();
          this.notify.success(this.l('SuccessfullyDeleted'));
        });
      }
    });

  }

  ngOnInit(): void {
  }

}
