import { Component, OnInit } from '@angular/core';
import { ClaimDto } from './claimDto';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectClaims, selectClaimsCount } from '../user-management-state/user-management.selectors';
import { claims } from '../user-management-state/user-management.actions';

@Component({
  selector: 'app-claims',
  templateUrl: './claims.component.html',
  styleUrls: ['./claims.component.scss']
})
export class ClaimsComponent implements OnInit {

  public claimsSource$: Observable<ClaimDto[]> = this.store.select(selectClaims);
  public claimsSourceCount$: Observable<number> = this.store.select(selectClaimsCount);

  constructor(private readonly store:Store) { }

  async ngOnInit() {
    this.claimsSource$.subscribe(data => {
      if (data.length === 0){
        this.store.dispatch(claims())
      }
    });
  }
}
