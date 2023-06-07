import { ClaimDto } from "../claims/claimDto";
import { RoleDto } from "../roles/roleDto";
import { UserDto } from "../user-list/userDto";

export interface UserManagementState{
  usersSource:UserDto[],
  claimsSource:ClaimDto[],
  rolesSource:RoleDto[]
}


