import { Component, OnInit } from '@angular/core';
import { UserManagementService } from '../user-management.service';
import { ClaimDto } from './claimDto';
import { Observable, lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-claims',
  templateUrl: './claims.component.html',
  styleUrls: ['./claims.component.scss']
})
export class ClaimsComponent implements OnInit {

  public claimsSource:ClaimDto[] = [];
  protected cancellationObservable: Observable<void> = new Observable();

  constructor(private readonly service:UserManagementService) { }

  async ngOnInit(): Promise<void> {
    this.claimsSource = await lastValueFrom(this.service.getClaimsList(this.cancellationObservable));
  }
}
