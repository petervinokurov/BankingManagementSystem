import { createReducer, on } from '@ngrx/store';
import { UserManagementState } from './user-management.state';
import { claimsSuccess, rolesSuccess, users, usersSuccess } from './user-management.actions';

export const userManagementState:UserManagementState ={
  usersSource: [] = [],
  rolesSource: [] = [],
  claimsSource: [] = []
};

export const userManagementReducer = createReducer(
  userManagementState,
  on(usersSuccess, (state, action) => ({...state, usersSource: action.users}))
  ,
  on(rolesSuccess, (state, action) =>
  ({...state, rolesSource: action.roles})),
  on(claimsSuccess, (state, action) =>
  ({...state, claimsSource: action.claims}))
);
