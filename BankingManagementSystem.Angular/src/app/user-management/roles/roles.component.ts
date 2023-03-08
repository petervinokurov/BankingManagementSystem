import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { RoleDto } from './roleDto';
import * as _ from 'lodash';
import { DataChange } from 'devextreme/ui/data_grid';
import { update } from 'lodash';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {

  protected cancellationObservable: Observable<void> = new Observable();
  public roles:RoleDto[] = [];
  //public changes: DataChange<any, any>[] = [];

  constructor(private readonly service:UserManagementService) { }

  async ngOnInit() {
    this.roles =  await lastValueFrom(this.service.getRolesList(this.cancellationObservable));
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
      let updateRoles = updated.map(x => {
        let r:RoleDto = new RoleDto();
        r.id = x.key;
        r.name = x.data.name;
        return r;
      });

      await lastValueFrom(this.service.updateRoles(updateRoles, this.cancellationObservable));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let deleteRoleIds = deleted.map(x => x.key as string);
      await lastValueFrom(this.service.deleteRoles(deleteRoleIds, this.cancellationObservable));
    }
  }
}
