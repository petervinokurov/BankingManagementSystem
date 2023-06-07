import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserManagementService } from "../user-management.service";
import { claims, claimsSuccess, roles, rolesSuccess, users, usersSuccess } from "./user-management.actions";
import { map, mergeMap } from "rxjs";
import { UserDto } from "../user-list/userDto";
import { RoleDto } from "../roles/roleDto";
import { ClaimDto } from "../claims/claimDto";

@Injectable()
export class UserManagementEffects {
  constructor(private actions$: Actions,
    private service:UserManagementService ) {}

    users$ = createEffect(
      () => this.actions$.pipe(ofType(users),
      mergeMap( () =>
         this.service.getUserList().pipe(map((users: UserDto[]) => usersSuccess({users})))
    )));

    roles$ = createEffect(
      () => this.actions$.pipe(ofType(roles),
      mergeMap( () =>
        this.service.getRolesList().pipe(map((roles: RoleDto[]) => rolesSuccess({roles})))))
    );

    claims$ = createEffect(
      () => this.actions$.pipe(ofType(claims),
      mergeMap(() =>
      this.service.getClaimsList().pipe(map((claims: ClaimDto[]) => claimsSuccess({claims})))))
    );
}
