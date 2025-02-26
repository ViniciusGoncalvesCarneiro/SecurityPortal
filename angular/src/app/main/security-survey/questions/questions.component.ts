import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
  templateUrl: './questions.component.html',
  styleUrls: ['questions.component.less'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})

export class QuestionsComponent extends AppComponentBase implements OnInit {

  @ViewChild('ExcelFileUpload', { static: false }) excelFileUpload: FileUpload;

  uploadUrl: string;

  constructor(
    injector: Injector,
    private _httpClient: HttpClient
  ) {
    super(injector);
  }

  uploadExcel(data: { files: File }): void {

    const formData: FormData = new FormData();
    const file = data.files[0];
    formData.append('file', file, file.name);

    this._httpClient
      .post<any>(this.uploadUrl, formData).pipe(
        finalize(() =>
          this.excelFileUpload.clear()
        )).subscribe((response) => {
          if (response.success) {
            this.notify.success(this.l('ImportUsersProcessStart'));
          } else if (response.error != null) {
            this.notify.error(this.l('ImportUsersUploadFailed'));
          }
        });
  }

  onUploadExcelError(): void {
    this.notify.error(this.l('ImportUsersUploadFailed'));
  }

  ngOnInit(): void {
    this.uploadUrl = AppConsts.remoteServiceBaseUrl + '/SecuritySurvey/UploadAwser';
  }

}
