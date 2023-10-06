import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { UserDto } from './userDto';
import { ClaimDto } from '../claims/claimDto';
import { RoleDto } from '../roles/roleDto';
import { DataChange } from 'devextreme/ui/data_grid';
import { NewUserDto } from '../new-user/newUserDto';
import { claims, createUsers, roles, updateUsers, users } from '../user-management-state/user-management.actions';
import { Store } from '@ngrx/store';
import { selectClaims, selectClaimsCount, selectRoles, selectRolesCount, selectUsers, selectUsersCount } from '../user-management-state/user-management.selectors';
import { CreateUsersRequest } from '../domain/createUsersRequest';
import { UpdateUsersRequest } from '../domain/UpdateUsersRequest';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  public users$ : Observable<(UserDto | undefined)[]> = this.store.select(selectUsers);
  public usersCount$ = this.store.select(selectUsersCount);

  public claimsSource$: Observable<ClaimDto[]> = this.store.select(selectClaims);
  public rolesSource$:Observable<RoleDto[]> = this.store.select(selectRoles);
  public claimsSourceCount$: Observable<number> = this.store.select(selectClaimsCount);
  public rolesSourceCount$:Observable<number> = this.store.select(selectRolesCount);

  constructor(private readonly service: UserManagementService,
    private store:Store) {
  }

  async ngOnInit() {
    this.usersCount$.subscribe(data =>{
      if (!data){
        this.store.dispatch(users());
      }
    });

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

  async saveUsers(e: any){

    const changes = (e.changes as DataChange<UserDto, string>[]);
    const inserted = changes.filter(c => c.type === 'insert');
    if (inserted.length > 0){
      const users = inserted.map(i =>{
        var user = i.data as UserDto;
        let newUserDto = new NewUserDto();
        newUserDto.userName = user.userName;
        newUserDto.email = user.email;
        newUserDto.roles = user.roles;
        newUserDto.claims = user.claims;
        return newUserDto;
      });
      const request = new CreateUsersRequest();
      request.newUsers = users;
      this.store.dispatch(createUsers({request}));
    }
    const updated = changes.filter(c => c.type === 'update');
    if (updated.length > 0){
      const usersForUpdate = changes.filter(c => c.type === 'update').map(x => {
        let data = x.data as UserDto;
        data.id = x.key;
        return data;
      });
      const request = new UpdateUsersRequest();
      request.users = usersForUpdate;
      this.store.dispatch(updateUsers({request}));
    }

    const deleted = changes.filter(c => c.type === 'remove');
    if (deleted.length > 0){
      let deleteUserIds = deleted.map(x => x.key as string);
      await lastValueFrom(this.service.deleteUsers(deleteUserIds));
    }
  }
}
