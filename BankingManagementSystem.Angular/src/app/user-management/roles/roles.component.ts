import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RoleDto } from './roleDto';
import { DataChange } from 'devextreme/ui/data_grid';
import { ClaimDto } from '../claims/claimDto';
import { claims, roles, createRoles, deleteRoles, updateRoles } from '../user-management-state/user-management.actions';
import { selectClaims, selectClaimsCount, selectRoles, selectRolesCount } from '../user-management-state/user-management.selectors';
import { Store } from '@ngrx/store';
import { CreateRolesRequest } from '../domain/createRolesRequest';
import { DeleteRolesRequest } from '../domain/deleteRolesRequest';
import { UpdateRolesRequest } from '../domain/updateRolesRequest';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {

  public claimsSource$: Observable<ClaimDto[]> = this.store.select(selectClaims);
  public rolesSource$:Observable<RoleDto[]> = this.store.select(selectRoles);
  public rolesSourceCount$:Observable<number> = this.store.select(selectRolesCount);
  public claimsSourceCount$: Observable<number> = this.store.select(selectClaimsCount);

  constructor(private store:Store) { }

  async ngOnInit() {
    this.rolesSourceCount$.subscribe(data => {
      if (!data){
        this.store.dispatch(roles())
      }
    });
    this.claimsSourceCount$.subscribe(data => {
      if (!data){
        this.store.dispatch(claims())
      }
    });
  }

  async onClaimsChanged(event: ClaimDto[], item: RoleDto){
    item.roleClaims = event;
    if (item.id){
      let request = new UpdateRolesRequest();
      request.updateRoles = [item];
      this.store.dispatch(updateRoles({request}));
    }
  }

  async saveRole(e: any){

    const changes = (e.changes as DataChange<RoleDto, string>[]);
    const inserted = changes.filter(c => c.type === 'insert');
    if (inserted.length > 0){
      let request = new CreateRolesRequest();
      request.newRoles = inserted.map(i => i.data as RoleDto);
      this.store.dispatch(createRoles({request}));
    }
    const updated = changes.filter(c => c.type === 'update');
    if (updated.length > 0){
      let request = new UpdateRolesRequest();
      request.updateRoles = changes.filter(c => c.type === 'update').map(x => {
        let data = x.data as RoleDto;
        data.id = x.key;
        return data;
      });
      this.store.dispatch(updateRoles({request}));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let request = new DeleteRolesRequest();
      request.roleIds = deleted.map(x => x.key);
      this.store.dispatch(deleteRoles({request}));
    }
  }
}
