import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { RoleDto } from './roleDto';
import { DataChange } from 'devextreme/ui/data_grid';
import { ClaimDto } from '../claims/claimDto';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {

  protected cancellationObservable: Observable<void> = new Observable();
  public roles:RoleDto[] = [];
  public claimsSource:ClaimDto[] = [];

  constructor(private readonly service:UserManagementService) { }

  async ngOnInit() {
    this.claimsSource = await lastValueFrom(this.service.getClaimsList(this.cancellationObservable));
    this.roles =  await lastValueFrom(this.service.getRolesList(this.cancellationObservable));
    this.roles.forEach(r => r.roleClaims = this.claimsSource.filter(cs => r.roleClaims.map(rc => rc.claimView).includes(cs.claimView)));
  }


  async saveRole(e: any){

    const changes = (e.changes as DataChange<RoleDto, string>[]);
    const inserted = changes.filter(c => c.type === 'insert');
    if (inserted.length > 0){
      const createRoles = inserted.map(i => i.data as RoleDto);
      await lastValueFrom(this.service.createNewRoles(createRoles, this.cancellationObservable));
    }
    const updated = changes.filter(c => c.type === 'update');
    if (updated.length > 0){
      const updateRolesIds = changes.filter(c => c.type === 'update').map(x => {
        let data = x.data as RoleDto;
        data.id = x.key;
        return data;
      });
      console.log(updateRolesIds);
      await lastValueFrom(this.service.updateRoles(updateRolesIds, this.cancellationObservable));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let deleteRoleIds = deleted.map(x => x.key as string);
      await lastValueFrom(this.service.deleteRoles(deleteRoleIds, this.cancellationObservable));
    }
  }
}
