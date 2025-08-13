import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectClaims, selectClaimsCount } from '../user-management-state/user-management.selectors';
import { claims } from '../user-management-state/user-management.actions';
import { ClaimDto } from 'src/app/generated-dto/claim-dto';

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
