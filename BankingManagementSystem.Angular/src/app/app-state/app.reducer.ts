import { createReducer, on } from '@ngrx/store';
import { loginSuccess, logout, userProfileSuccess, userTokenInvalid, userTokenValid } from './app.actions';
import { AppState } from './app.state';
import { UserDto } from '../user-management/user-list/userDto';

export const initialState:AppState ={
  isLogin: false,
  userName: '',
  userEmail: ''
};

export const appReducer = createReducer(
  initialState,
  on(userTokenValid, (state) =>
  ({...state, isLogin: true})
  ),
  on(userTokenInvalid, (state) =>
    ({...state, isLogin: false})
  ),

  on(loginSuccess, (state) =>
    state = ({...state, isLogin: true})),

  on(logout, (state) =>
    ({...state, isLogin: false})),

  on(userProfileSuccess, (state, action) => {
    const userDto = action.response.user as UserDto;
    state = ({...state, userName: userDto.userName.toString()});
    state = ({...state, userEmail: userDto.email.toString()});
    return state;
  })
);
