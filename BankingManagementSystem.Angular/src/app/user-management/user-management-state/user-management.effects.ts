import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserManagementService } from "../user-management.service";
import { claims, claimsSuccess, createRoles, createRolesSuccess, createUsers, createUsersSuccess, deleteRoles, deleteRolesSuccess, roles, rolesSuccess, updateRoles, updateRolesSuccess, updateUsers, updateUsersSuccess, users, usersSuccess } from "./user-management.actions";
import { map, merge, mergeMap } from "rxjs";
import { UserDto } from "../user-list/userDto";
import { RoleDto } from "../roles/roleDto";
import { ClaimDto } from "../claims/claimDto";
import { CreateRolesResponse } from "../domain/createRolesResponse";
import { DeleteRolesResponse } from "../domain/deleteRolesResponse";
import { UpdateRolesResponse } from "../domain/updateRolesResponse";
import { CreateUsersRequest } from "../domain/createUsersRequest";
import { CreateUsersResponse } from "../domain/createUsersResponse";
import { UpdateUsersResponse } from "../domain/UpdateUsersResponse";

@Injectable()
export class UserManagementEffects {
  constructor(private actions$: Actions,
    private service:UserManagementService ) {}

    users$ = createEffect(
      () => this.actions$.pipe(ofType(users),
      mergeMap( () =>
         this.service.getUserList().pipe(map((users: UserDto[]) => usersSuccess({users})))
    )));
    createUsers$ = createEffect(
      () => this.actions$.pipe(ofType(createUsers),
      mergeMap((payload) =>
      this.service.createNewUsers(payload.request).pipe(map((response: CreateUsersResponse) => createUsersSuccess({response})))))
    );
    updateUsers$ = createEffect(
      () => this.actions$.pipe(ofType(updateUsers),
      mergeMap((payload) =>
      this.service.updateUsers(payload.request).pipe(map((response: UpdateUsersResponse) => updateUsersSuccess({response})))))
    );

    roles$ = createEffect(
      () => this.actions$.pipe(ofType(roles),
      mergeMap( () =>
        this.service.getRolesList().pipe(map((roles: RoleDto[]) => rolesSuccess({roles})))))
    );
    createRoles$ = createEffect(
      () => this.actions$.pipe(ofType(createRoles),
      mergeMap((payload) =>
      this.service.createNewRoles(payload.request).pipe(map((response: CreateRolesResponse) => createRolesSuccess({response})))))
    );
    deleteRoles$ = createEffect(
      () => this.actions$.pipe(ofType(deleteRoles),
      mergeMap((payload) =>
      this.service.deleteRoles(payload.request).pipe(map((response: DeleteRolesResponse) => deleteRolesSuccess({response})))))
    );
    updateRoles$ = createEffect(
      () => this.actions$.pipe(ofType(updateRoles),
      mergeMap((payload) =>
      this.service.updateRoles(payload.request).pipe(map((response: UpdateRolesResponse) => updateRolesSuccess({response})))))
    );

    claims$ = createEffect(
      () => this.actions$.pipe(ofType(claims),
      mergeMap(() =>
      this.service.getClaimsList().pipe(map((claims: ClaimDto[]) => claimsSuccess({claims})))))
    );
}
