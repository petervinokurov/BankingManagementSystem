import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserManagementState } from "./user-management.state";
import { userAdapter } from "../user-list/userDto";
import { RoleDto, roleAdapter } from "../roles/roleDto";
import { ClaimDto, claimAdapter } from "../claims/claimDto";

export const selectUserManagementState = createFeatureSelector<UserManagementState>('userManagement');

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

    return roleAdapter.getSelectors().selectAll(userManagement.rolesSource).map(role => {
      let cl = claims.filter(c => role.roleClaims.find(rc => rc.claimView === c.claimView));
      return {...role, roleClaims: cl};
    });
  }
);

export const selectRolesCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => roleAdapter.getSelectors().selectAll(userManagement.rolesSource).length
);

export const selectUsers = createSelector(
  selectUserManagementState,
  selectRoles,
  selectClaims,
  (userManagement: UserManagementState, roles, claims) => {
    return userAdapter.getSelectors().selectAll(userManagement.usersSource).map(user => {
      let userRoles = roles.filter(r => user.roles.find(ur => ur.id === r.id));
      let userClaims = claims.filter(c => user.claims.find(uc => uc.claimView === c.claimView));
      return {...user, roles: userRoles, claims: userClaims};
    })}
);
