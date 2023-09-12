import { ClaimDto, ClaimsState } from "../claims/claimDto";
import { RoleDto, RolesState } from "../roles/roleDto";
import { UserDto, UsersState } from "../user-list/userDto";

export interface UserManagementState{
  usersSource: UsersState,
  claimsSource:ClaimsState,
  rolesSource:RolesState
}


