import { AfterViewInit, Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { PowerBIReportEmbedComponent } from 'powerbi-client-angular';
import { IReportEmbedConfiguration, models, Report, service, Embed } from 'powerbi-client';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PowerBIReportServiceProxy } from '@shared/service-proxies/service-proxies';
import { environment } from 'environments/environment';

@Component({
  templateUrl: './power-bi-report-view.component.html',
  animations: [appModuleAnimation()],
  encapsulation: ViewEncapsulation.None
})

export class PowerBiReportViewComponent extends AppComponentBase implements AfterViewInit, OnInit {

  @ViewChild(PowerBIReportEmbedComponent) reportObj!: PowerBIReportEmbedComponent;

  // Flag for button toggles
  isEmbedded = true;
  accessToken: string;
  elements!: HTMLElement
  // Overall status message of embedding
  displayMessage = 'The report is bootstrapped. Click Embed Report button to set the access token.';
  // CSS Class to be passed to the wrapper
  reportClass = 'report-container2';
  // Flag which specify the type of embedding
  phasedEmbeddingFlag = false;
  // Configuracion
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
  //reportClass = 'report-container';

  // Flag which specify the type of embedding
  //phasedEmbeddingFlag = false;

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
    ['pageChanged', (event) => {
      this.dimension(this.elements)
      this.displayPowerBi1(this.elements, "block")

    }],
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

  ngAfterViewInit(): void {
    const element = document.getElementsByClassName(this.reportClass);
    if (element.length > 0) {
      this.elements = element[0] as HTMLElement
      this.displayPowerBi1(this.elements, "none")
    }
  }

  displayPowerBi(elements: HTMLElement, display: "none" | "block") {
    elements.style.display = display
  }

  displayPowerBi1(element: HTMLElement, display: "none" | "block"): HTMLElement {
    element.style.display = display
    return element
  }
  dimension(element: HTMLElement): HTMLElement {
    element.style.height = "75vh";
    element.style.margin = "8px auto";
    element.style.width = "90%";
    return element
  }

  getAccessToken() {
    this.spinnerService.show();
    this._powerBIReportsServiceProxy.getAccessToken()
      .subscribe((result) => {
        this.accessToken = result;

        this.reportConfig = {
          type: 'report',
          id: environment.id,
          embedUrl: environment.embedUrl,
          tokenType: models.TokenType.Aad,
          accessToken: this.accessToken,
        };

        this.spinnerService.hide();
      }, (error) => {
        console.error('Erro ao obter o token de acesso:', error);
        this.spinnerService.hide();
      });
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
