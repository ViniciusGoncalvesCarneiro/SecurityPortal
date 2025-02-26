import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [

                    // Não esquecer as permissions
                    {
                        path: 'security-survey/questions',
                        loadChildren: () => import('./security-survey/questions/question.module').then(m => m.QuestionModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-iso',
                        loadChildren: () => import('./security-survey/queries/cis-to-iso/cis-to-iso.module').then(m => m.CisToIsoModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-mitre',
                        loadChildren: () => import('./security-survey/queries/cis-to-mitre/cis-to-mitre.module').then(m => m.CisToMitreModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/cis-to-nist',
                        loadChildren: () => import('./security-survey/queries/cis-to-nist/cis-to-nist.module').then(m => m.CisToNistModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/iso',
                        loadChildren: () => import('./security-survey/queries/iso/iso.module').then(m => m.IsoModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/mitre',
                        loadChildren: () => import('./security-survey/queries/mitre/mitre.module').then(m => m.MitreModule),
                        data: { permission: '' }
                    },
                    {
                        path: 'security-survey/queries/nist',
                        loadChildren: () => import('./security-survey/queries/nist/nist.module').then(m => m.NistModule),
                        data: { permission: '' }
                    },
                    // Não esquecer as permissions

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
    exports: [RouterModule],
})
export class MainRoutingModule {}
