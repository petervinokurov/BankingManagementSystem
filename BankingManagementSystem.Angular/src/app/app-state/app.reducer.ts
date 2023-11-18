import { createReducer, on } from '@ngrx/store';
import { loginSuccess, logout, refreshTokenSuccess, userProfileSuccess, userTokenValid } from './app.actions';
import { AppState } from './app.state';
import { UserDto } from '../user-management/user-list/userDto';
import { UserProfileDto, initialUserProfileState, userProfileAdapter } from '../app-components/user-profile/userProfileDto';

export const initialState:AppState ={
  isLogin: false,
  currentUserId: '',
  userProfile: initialUserProfileState
};

export const appReducer = createReducer(
  initialState,
  on(userTokenValid, (state) =>
  ({...state, isLogin: true})
  ),
  on(refreshTokenSuccess, (state) =>
    ({...state, isLogin: true})
  ),

  on(loginSuccess, (state) =>
    state = ({...state, isLogin: true})),

  on(logout, (state) =>
    ({...state, isLogin: false})),
//on(claimsSuccess, (state, action) => ({...state, claimsSource: claimAdapter.addMany(action.claims, state.claimsSource)}))
  on(userProfileSuccess, (state, action) =>
    ({...state, currentUserId: action.response.user.id, userProfile: userProfileAdapter.addOne(action.response.user, state.userProfile)}))
);
