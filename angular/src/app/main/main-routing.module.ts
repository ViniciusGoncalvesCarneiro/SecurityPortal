import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'power-bi-reports',
                        loadChildren: () => import('./power-bi-reports/power-bi-report.module').then(m => m.PowerBiReportModule),
                        data: { permission: 'Pages.PowerBIReports' }
                    },
                    {
                        path: 'security-survey/questions',
                        loadChildren: () => import('./security-survey/questions/question.module').then(m => m.QuestionModule),
                        data: { permission: 'Pages.Questions' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-iso',
                        loadChildren: () => import('./security-survey/queries/cis-to-iso/cis-to-iso.module').then(m => m.CisToIsoModule),
                        data: { permission: 'Pages.Queries.CisToIso' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-mitre',
                        loadChildren: () => import('./security-survey/queries/cis-to-mitre/cis-to-mitre.module').then(m => m.CisToMitreModule),
                        data: { permission: 'Pages.Queries.CisToMitre' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-nist',
                        loadChildren: () => import('./security-survey/queries/cis-to-nist/cis-to-nist.module').then(m => m.CisToNistModule),
                        data: { permission: 'Pages.Queries.CisToNist' }
                    },
                    {
                        path: 'security-survey/queries/iso',
                        loadChildren: () => import('./security-survey/queries/iso/iso.module').then(m => m.IsoModule),
                        data: { permission: 'Pages.Queries.Iso' }
                    },
                    {
                        path: 'security-survey/queries/mitre',
                        loadChildren: () => import('./security-survey/queries/mitre/mitre.module').then(m => m.MitreModule),
                        data: { permission: 'Pages.Queries.Mitre' }
                    },
                    {
                        path: 'security-survey/queries/nist',
                        loadChildren: () => import('./security-survey/queries/nist/nist.module').then(m => m.NistModule),
                        data: { permission: 'Pages.Queries.Nist' }
                    },
                    {
                        path: 'dashboard',
                        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
                        data: { permission: 'Pages.Tenant.Dashboard' },
                    },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },
                ],
            },
        ]),
    ],
    exports: [
        RouterModule
    ],
})

export class MainRoutingModule { }
