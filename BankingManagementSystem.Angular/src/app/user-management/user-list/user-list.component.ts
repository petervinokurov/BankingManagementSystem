import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { UserDto } from './userDto';
import { ClaimDto } from '../claims/claimDto';
import { RoleDto } from '../roles/roleDto';
import { DataChange } from 'devextreme/ui/data_grid';
import { NewUserDto } from '../new-user/newUserDto';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  protected cancellationObservable: Observable<void> = new Observable();

  public users:UserDto[] = [];
  public claimsSource:ClaimDto[] = [];
  public rolesSource:RoleDto[] = [];

  constructor(private readonly service: UserManagementService) {
  }

  async ngOnInit() {
    this.users = await lastValueFrom(this.service.getUserList(this.cancellationObservable));
    this.claimsSource = await lastValueFrom(this.service.getClaimsList(this.cancellationObservable));
    this.rolesSource =  await lastValueFrom(this.service.getRolesList(this.cancellationObservable));
    this.users.forEach(r => {
      r.claims = this.claimsSource.filter(cs => r.claims.map(rc => rc.claimView).includes(cs.claimView));
      r.roles = this.rolesSource.filter(cs => r.roles.map(rc => rc.name).includes(cs.name));
    });
  }

  async saveUsers(e: any){

    const changes = (e.changes as DataChange<UserDto, string>[]);
    const inserted = changes.filter(c => c.type === 'insert');
    if (inserted.length > 0){
      const createUsers = inserted.map(i =>{
        var user = i.data as UserDto;
        let newUserDto = new NewUserDto();
        newUserDto.userName = user.userName;
        newUserDto.email = user.email;
        newUserDto.roles = user.roles;
        newUserDto.claims = user.claims;
        return newUserDto;
      } );
      console.log(createUsers);
      await lastValueFrom(this.service.createNewUsers(createUsers, this.cancellationObservable));
    }
    const updated = changes.filter(c => c.type === 'update');
    if (updated.length > 0){
      const usersForUpdate = changes.filter(c => c.type === 'update').map(x => {
        let data = x.data as UserDto;
        data.id = x.key;
        return data;
      });
      await lastValueFrom(this.service.updateUsers(usersForUpdate, this.cancellationObservable));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let deleteUserIds = deleted.map(x => x.key as string);
      await lastValueFrom(this.service.deleteUsers(deleteUserIds, this.cancellationObservable));
    }
  }
}
