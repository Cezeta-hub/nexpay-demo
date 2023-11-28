// Angular
import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
// NgZorro
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
// Components
import { CZValidUntilTagComponent } from './valid-until-tag.component';
// Interfaces
import { Rate } from '../../../interfaces/FxRatesAPI/rate.interface';

@Component({
  selector: 'cz-contract-card',
  standalone: true,
  imports: [
    CommonModule,
    NzCardModule,
    NzSkeletonModule,
    CZValidUntilTagComponent,
  ],
  host: { ngSkipHydration: 'true' },
  template: `
    @if (showCard) {
    <nz-card style="display: flex; flex-direction: vertical">
      @if (rate && amount !== undefined) {
      <div style="width: 100%; margin-bottom: 10px">
        Current Rate: {{ rate.exchangeRate }}
      </div>
      <div style="width: 100%; margin-bottom: 10px">
        Final Amount:
        {{ rate.currencyTo?.symbol ?? '-' + ' ' }}
        {{ getFinalAmount | number : '1.2' }}
      </div>
      <cz-valid-until-tag
        [expiredOn]="rate.expiredOn"
        customText="Rate valid until: "
        customExpiredText="Rate expired"
      ></cz-valid-until-tag>
      } @else {
      <nz-skeleton [nzActive]="true"></nz-skeleton>
      }
    </nz-card>
    }
  `,
})
export class CZContractCardComponent implements OnInit {
  @Input() showCard: boolean = false;

  @Input() rate?: Rate;
  @Input() amount!: number;

  constructor() {}

  ngOnInit(): void {}

  protected get getFinalAmount() {
    return this.amount * (this.rate?.exchangeRate ?? 0);
  }
}
