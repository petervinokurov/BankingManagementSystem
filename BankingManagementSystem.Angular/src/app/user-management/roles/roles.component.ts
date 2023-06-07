import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { RoleDto } from './roleDto';
import { DataChange } from 'devextreme/ui/data_grid';
import { ClaimDto } from '../claims/claimDto';
import { claims, roles } from '../user-management-state/user-management.actions';
import { selectClaims, selectClaimsCount, selectRoles } from '../user-management-state/user-management.selectors';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {

  public claimsSource$: Observable<ClaimDto[]> = this.store.select(selectClaims);
  public rolesSource$:Observable<RoleDto[]> = this.store.select(selectRoles);
  public claimsSourceCount$: Observable<number> = this.store.select(selectClaimsCount);

  constructor(private readonly service:UserManagementService,
    private store:Store) { }

  async ngOnInit() {
    this.rolesSource$.subscribe(data => {
      if (data.length === 0){
        this.store.dispatch(roles())
      }
    });

    this.claimsSource$.subscribe(data => {
      if (data.length === 0){
        this.store.dispatch(claims())
      }
    });
  }

  async saveRole(e: any){

    const changes = (e.changes as DataChange<RoleDto, string>[]);
    const inserted = changes.filter(c => c.type === 'insert');
    if (inserted.length > 0){
      const createRoles = inserted.map(i => i.data as RoleDto);
      await lastValueFrom(this.service.createNewRoles(createRoles));
    }
    const updated = changes.filter(c => c.type === 'update');
    if (updated.length > 0){
      const rolesForUpdate = changes.filter(c => c.type === 'update').map(x => {
        let data = x.data as RoleDto;
        data.id = x.key;
        return data;
      });
      await lastValueFrom(this.service.updateRoles(rolesForUpdate));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let deleteRoleIds = deleted.map(x => x.key as string);
      await lastValueFrom(this.service.deleteRoles(deleteRoleIds));
    }
  }
}
