import { createAction, props } from "@ngrx/store";
import { UserDto } from "../user-list/userDto";
import { RoleDto } from "../roles/roleDto";
import { ClaimDto } from "../claims/claimDto";
import { CreateRolesCommand } from "../domain/createRolesRequest";
import { CreateRolesResponse } from "../domain/createRolesResponse";
import { DeleteRolesCommand } from "../domain/deleteRolesRequest";
import { DeleteRolesResponse } from "../domain/deleteRolesResponse";
import { UpdateRolesCommand } from "../domain/updateRolesRequest";
import { UpdateRolesResponse } from "../domain/updateRolesResponse";
import { CreateUsersCommand } from "../domain/createUsersRequest";
import { CreateUsersResponse } from "../domain/createUsersResponse";
import { UpdateUsersCommand } from "../domain/updateUsersRequest";
import { UpdateUsersResponse } from "../domain/updateUsersResponse";
import { DeleteUsersResponse } from "../domain/deleteUsersResponse";
import { DeleteUsersCommand } from "../domain/deleteUsersRequest";

export const users = createAction('[User Managment Component] Users');
export const usersSuccess = createAction('[User Managment Component] Users Success', props<{ users: UserDto[] }>());
export const createUsers = createAction('[User Managment Component] Create Users', props<{ request: CreateUsersCommand }>());
export const createUsersSuccess = createAction('[User Managment Component] Create Users Success', props<{ response: CreateUsersResponse }>());
export const updateUsers = createAction('[User Managment Component] Update Users', props<{ request: UpdateUsersCommand }>());
export const updateUsersSuccess = createAction('[User Managment Component] Update Users Success', props<{ response: UpdateUsersResponse }>());
export const deleteUsers = createAction('[User Managment Component] Delete Users', props<{ request: DeleteUsersCommand }>());
export const deleteUsersSuccess = createAction('[User Managment Component] Delete Users Success', props<{ response: DeleteUsersResponse }>());

export const roles = createAction('[User Managment Component] Roles');
export const rolesSuccess = createAction('[User Managment Component] Roles Success', props<{ roles: RoleDto[] }>());
export const createRoles = createAction('[User Managment Component] Create Roles', props<{ request: CreateRolesCommand }>());
export const createRolesSuccess = createAction('[User Managment Component] Create Roles Success', props<{ response: CreateRolesResponse }>());
export const updateRoles = createAction('[User Managment Component] Update Roles', props<{ request: UpdateRolesCommand }>());
export const updateRolesSuccess = createAction('[User Managment Component] Update Roles Success', props<{ response: UpdateRolesResponse }>());
export const deleteRoles = createAction('[User Managment Component] Delete Roles', props<{ request: DeleteRolesCommand }>());
export const deleteRolesSuccess = createAction('[User Managment Component] Delete Roles Success', props<{ response: DeleteRolesResponse }>())

export const claims = createAction('[User Managment Component] Claims');
export const claimsSuccess = createAction('[User Managment Component] Claims Success', props<{ claims: ClaimDto[] }>());
//TODO implement custom claims
export const createClaims = createAction('[User Managment Component] Create Claims', props<{ claims: ClaimDto[] }>());
export const createClaimsSuccess = createAction('[User Managment Component] Create Claims Success');
export const updateClaims = createAction('[User Managment Component] Update Claims', props<{ claims: ClaimDto[] }>());
export const updateClaimsSuccess = createAction('[User Managment Component] Update Claims Success');
export const deleteClaims = createAction('[User Managment Component] Delete Claims', props<{ claims: ClaimDto[] }>());
export const deleteClaimsSuccess = createAction('[User Managment Component] Delete Claims Success')
