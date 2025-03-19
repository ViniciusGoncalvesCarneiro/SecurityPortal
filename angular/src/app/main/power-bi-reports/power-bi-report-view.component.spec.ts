import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PowerBiReportViewComponent } from './power-bi-report-view.component';

describe('PowerBiReportViewComponent', () => {
  let component: PowerBiReportViewComponent;
  let fixture: ComponentFixture<PowerBiReportViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PowerBiReportViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PowerBiReportViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
