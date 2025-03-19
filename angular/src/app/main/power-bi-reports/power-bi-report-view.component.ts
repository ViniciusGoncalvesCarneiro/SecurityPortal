import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  templateUrl: './power-bi-report-view.component.html',
  animations: [appModuleAnimation()],
  encapsulation: ViewEncapsulation.None
})

export class PowerBiReportViewComponent extends AppComponentBase implements OnInit {


  breadcrumbs: BreadcrumbItem[] =
    [
      new BreadcrumbItem(this.l('PowerBIReports'), '/app/main/power-bi-reports')
    ]

  constructor(
    injector: Injector
    //,private _powerBIReportsServiceProxy: PowerBIReportServiceProxy,

  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

}
