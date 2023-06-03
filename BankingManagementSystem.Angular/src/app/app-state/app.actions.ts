import { createAction, props } from '@ngrx/store';
import { LoginDto } from '../login/loginDto';
import { UserDto } from '../user-management/user-list/userDto';
import { UserProfileResponse } from '../app-responses/user-profile-response';

export const login = createAction('[App Component] Login', props<{ loginDto: LoginDto }>());
export const loginSuccess = createAction('[App Component] Login Success');
export const userTokenValid = createAction('[App Component] User Token Valid');
export const userTokenInvalid = createAction('[App Component] User Token Invalid');
export const logout = createAction('[App Component] Logout');
export const logoutSuccess = createAction('[App Component] Logout Success');
export const userProfile = createAction('[App Component] User Profile');
export const userProfileSuccess = createAction('[AppComponent] User Profile Sucess', props<{ response: UserProfileResponse }>());

