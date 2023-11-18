import { ClaimsState } from "../claims/claimDto";
import { RolesState } from "../roles/roleDto";
import { UsersState } from "../user-list/userDto";

export interface UserManagementState{
  usersSource: UsersState,
  claimsSource:ClaimsState,
  rolesSource:RolesState
}


