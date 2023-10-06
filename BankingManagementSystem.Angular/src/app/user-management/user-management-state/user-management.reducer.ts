import { createReducer, on } from '@ngrx/store';
import { UserManagementState } from './user-management.state';
import { claimsSuccess, createRolesSuccess, createUsersSuccess, deleteRolesSuccess, rolesSuccess, updateRolesSuccess, updateUsersSuccess, usersSuccess } from './user-management.actions';
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
  on(usersSuccess, (state, action) => ({...state,
    usersSource: userAdapter.addMany(action.users, state.usersSource),
    rolesSource: roleAdapter.upsertMany(action.users.flatMap(u => u.roles), state.rolesSource),
    claimsSource: claimAdapter.upsertMany(action.users.flatMap(u => u.claims), state.claimsSource) })),
  on(createUsersSuccess, (state, action) => ({...state,
    usersSource: userAdapter.addMany(action.response.newUsers, state.usersSource),
    rolesSource: roleAdapter.upsertMany(action.response.newUsers.flatMap(u => u.roles), state.rolesSource),
    claimsSource: claimAdapter.upsertMany(action.response.newUsers.flatMap(u => u.claims), state.claimsSource)
  })),
  on(updateUsersSuccess, (state, action) => ({...state,
    usersSource: userAdapter.upsertMany(action.response.users, state.usersSource)
   })),
  on(rolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.addMany(action.roles, state.rolesSource)
    , claimsSource: claimAdapter.upsertMany(action.roles.flatMap(r => r.roleClaims), state.claimsSource)})),
  on(createRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.addMany(action.response.createdRoles, state.rolesSource)})),
  on(deleteRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.removeMany(action.response.deletedRoleIds, state.rolesSource)})),
  on(updateRolesSuccess, (state, action) => ({...state, rolesSource: roleAdapter.upsertMany(action.response.updatedRoles, state.rolesSource)})),
  on(claimsSuccess, (state, action) => ({...state, claimsSource: claimAdapter.addMany(action.claims, state.claimsSource)}))
);
