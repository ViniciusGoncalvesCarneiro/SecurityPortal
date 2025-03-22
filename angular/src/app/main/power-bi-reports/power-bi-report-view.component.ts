import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { PowerBIReportEmbedComponent } from 'powerbi-client-angular';
import { IReportEmbedConfiguration, models, Report, service, Embed } from 'powerbi-client';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PowerBIReportServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './power-bi-report-view.component.html',
  animations: [appModuleAnimation()],
  encapsulation: ViewEncapsulation.None
})

export class PowerBiReportViewComponent extends AppComponentBase implements OnInit {

  @ViewChild(PowerBIReportEmbedComponent) public reportObj!: PowerBIReportEmbedComponent;

  // Flag for button toggles
  isFilterPaneVisible: boolean = true;
  isThemeApplied: boolean = false;
  isZoomedOut: boolean = false;
  isDataSelectedEvent = false;

  // Constants for zoom levels
  zoomOutLevel = 0.5;
  zoomInLevel = 0.9;

  // Button text
  filterPaneBtnText: string = "Hide filter pane";
  themeBtnText: string = "Set theme";
  zoomBtnText: string = "Zoom out";
  dataSelectedBtnText = "Show dataSelected event in dialog";




  // CSS Class to be passed to the wrapper
  reportClass = 'report-container';

  // Flag which specify the type of embedding
  phasedEmbeddingFlag = false;

  reportConfig: IReportEmbedConfiguration = {
    type: 'report',
    id: undefined,
    embedUrl: undefined,
    tokenType: models.TokenType.Embed,
    accessToken: undefined,
    settings: {
      panes: {
        filters: {
          expanded: false,
          visible: false
        }
      },
      background: models.BackgroundType.Transparent,
    },
    hostname: "https://app.powerbi.com"
  };

  eventHandlersMap = new Map([
    [
      'loaded', () => {
        const report = this.reportObj.getReport();
        report.setComponentTitle('Embedded report');
        console.log('Report has loaded');
      },
    ],
    ['rendered', () =>
      console.log('Report has rendered')
    ],
    [
      'error', (event?: service.ICustomEvent<any>) => {
        if (event) {
          console.error(event.detail);
        }
      },
    ],
    [
      'visualClicked', () => console.log('visual clicked')
    ],
    [
      'pageChanged', (event) => console.log(event)
    ],
  ]) as Map<string, (event?: service.ICustomEvent<any>, embeddedEntity?: Embed) => void | null>;

  breadcrumbs: BreadcrumbItem[] =
    [
      new BreadcrumbItem(this.l('PowerBIReports'), '/app/main/power-bi-reports')
    ]

  constructor(
    injector: Injector,
    private _powerBIReportsServiceProxy: PowerBIReportServiceProxy,

  ) {
    super(injector);
  }

  getAccessToken() {

    this.spinnerService.show();
    this._powerBIReportsServiceProxy.getAccessToken()
      .subscribe((result) => {
        this.reportConfig.id = '0cafa534-6e24-45e3-8ffe-ae39d98c7695';
        this.reportConfig.embedUrl = 'https://app.powerbi.com/reportEmbed?reportId=0cafa534-6e24-45e3-8ffe-ae39d98c7695&groupId=6efe988a-2e09-4cfb-ae4c-8de4ae58d275&w=2&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLUJSQVpJTC1TT1VUSC1yZWRpcmVjdC5hbmFseXNpcy53aW5kb3dzLm5ldCIsImVtYmVkRmVhdHVyZXMiOnsidXNhZ2VNZXRyaWNzVk5leHQiOnRydWV9fQ%3d%3d';
        this.reportConfig.accessToken = result;
        this.reportConfig.settings.panes.filters.expanded = true;
        this.reportConfig.settings.panes.filters.visible = true;
        this.spinnerService.hide();
      });


    console.log(this.reportConfig);

  }
  /**
   * Toggle zoom
  */
  public async toggleZoom(): Promise<void> {
    const report: Report = this.reportObj.getReport();

    if (!report) {
      //this.displayMessage = 'Report not available.';
      //console.log(this.displayMessage);
      return;
    }

    try {
      const newZoomLevel = this.isZoomedOut ? this.zoomInLevel : this.zoomOutLevel;
      this.isZoomedOut = !this.isZoomedOut;
      this.zoomBtnText = this.isZoomedOut ? "Zoom in" : "Zoom out";
      await report.setZoom(newZoomLevel);
    }
    catch (errors) {
      console.log(errors);
    }
  }

  /**
  * Refresh report event
  */
  async refreshReport(): Promise<void> {

    const report: Report = this.reportObj.getReport();

    if (!report) {
      //this.displayMessage = 'Report not available.';
      //console.log(this.displayMessage);
      return;
    }

    try {
      await report.refresh();
      //this.displayMessage = 'The report has been refreshed successfully.';
    }
    catch (errors: any) {
      //this.displayMessage = errors.detailedMessage;
      //console.log(errors);
    }
  }

  /**
  * Full screen event
  */
  enableFullScreen(): void {

    const report: Report = this.reportObj.getReport();

    if (!report) {
      //this.displayMessage = 'Report not available.';
      //console.log(this.displayMessage);
      return;
    }

    report.fullscreen();
  }

  ngOnInit(): void {

    this.getAccessToken();

  }

}
