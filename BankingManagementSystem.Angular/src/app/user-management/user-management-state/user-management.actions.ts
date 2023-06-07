import { createAction, props } from "@ngrx/store";
import { UserDto } from "../user-list/userDto";
import { RoleDto } from "../roles/roleDto";
import { ClaimDto } from "../claims/claimDto";

export const users = createAction('[User Managment Component] Users');
export const usersSuccess = createAction('[User Managment Component] Users Success', props<{ users: UserDto[] }>());
export const roles = createAction('[User Managment Component] Roles');
export const rolesSuccess = createAction('[User Managment Component] Roles Success', props<{ roles: RoleDto[] }>());
export const claims = createAction('[User Managment Component] Claims');
export const claimsSuccess = createAction('[User Managment Component] Claims Success', props<{ claims: ClaimDto[] }>());
