import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserManagementState } from "./user-management.state";
import { userAdapter } from "../user-list/userDto";
import { RoleDto, roleAdapter } from "../roles/roleDto";
import { claimAdapter } from "../claims/claimDto";

export const selectUserManagementState = createFeatureSelector<UserManagementState>('userManagement');

export const selectUsers = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userAdapter.getSelectors().selectAll(userManagement.usersSource)
);

export const selectUsersCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userAdapter.getSelectors().selectAll(userManagement.usersSource).length
);

export const selectClaims = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => claimAdapter.getSelectors().selectAll(userManagement.claimsSource)
);

export const selectClaimsCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => claimAdapter.getSelectors().selectAll(userManagement.claimsSource).length
);

export const selectRoles = createSelector(
  selectUserManagementState,
  selectClaims,
  (userManagement: UserManagementState, claims) => {

    let roles = roleAdapter.getSelectors().selectAll(userManagement.rolesSource);
    /*return roleAdapter.getSelectors().selectAll(userManagement.rolesSource).map(role => {
      const storeClaims = role.roleClaims.map(c => claims.find(cc => cc.claimValue === c.claimView)!);
      //role.roleClaims = {...role.roleClaims, storeClaims};
      return {...role, roleClaims:storeClaims};
    });*/

    return roles;
  }
);

export const selectRolesCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => roleAdapter.getSelectors().selectAll(userManagement.rolesSource).length
);
