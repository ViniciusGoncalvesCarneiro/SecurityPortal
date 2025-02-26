import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  templateUrl: './cis-to-iso.component.html',
  styleUrls: ['./cis-to-iso.component.css'],
  animations: [appModuleAnimation()],
})

export class CisToIsoComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

}
