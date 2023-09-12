import { createReducer, on } from '@ngrx/store';
import { UserManagementState } from './user-management.state';
import { claimsSuccess, createRolesSuccess, deleteRolesSuccess, rolesSuccess, updateRolesSuccess, usersSuccess } from './user-management.actions';
import { initialUserState, userAdapter } from '../user-list/userDto';
import { initialRoleState, roleAdapter } from '../roles/roleDto';
import { claimAdapter, initialClaimState } from '../claims/claimDto';

export const userManagementState:UserManagementState ={
  usersSource: initialUserState,
  rolesSource: initialRoleState,
  claimsSource: initialClaimState
};

export const userManagementReducer = createReducer(
  userManagementState,
  on(usersSuccess, (state, action) => ({...state, usersSource: userAdapter.addMany(action.users, state.usersSource) })),
  on(rolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.addMany(action.roles, state.rolesSource)})),
  on(createRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.addMany(action.response.createdRoles, state.rolesSource)})),
  on(deleteRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.removeMany(action.response.deletedRoleIds, state.rolesSource)})),
  on(updateRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.upsertMany(action.response.updatedRoles, state.rolesSource)})),
  on(claimsSuccess, (state, action) => ({...state, claimsSource: claimAdapter.addMany(action.claims, state.claimsSource)}))
);
