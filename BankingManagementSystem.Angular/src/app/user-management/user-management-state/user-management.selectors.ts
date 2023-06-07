import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserManagementState } from "./user-management.state";

export const selectUserManagementState = createFeatureSelector<UserManagementState>('userManagement');

export const selectUsers = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userManagement.usersSource
);

export const selectRoles = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userManagement.rolesSource
);

export const selectClaims = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userManagement.claimsSource
);

export const selectRolesCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userManagement.rolesSource.length
);

export const selectClaimsCount = createSelector(
  selectUserManagementState,
  (userManagement: UserManagementState) => userManagement.claimsSource.length
);
