import { createAction, props } from '@ngrx/store';
import { LoginDto } from '../login/loginDto';
import { UserProfileResponse } from '../app-responses/user-profile-response';
import { UpdateProfilePhotoResponse } from '../app-responses/user-photo-response';
import { UpdateProfilePhotoCommand } from '../app-requests/updateProfilePhotoRequest';

export const login = createAction('[App Component] Login', props<{ loginDto: LoginDto }>());
export const loginSuccess = createAction('[App Component] Login Success');
export const userTokenValid = createAction('[App Component] User Token Valid');
export const userTokenInvalid = createAction('[App Component] User Token Invalid');
export const refreshTokenSuccess = createAction('[App Component] User Token Refreshed');
export const logout = createAction('[App Component] Logout');
export const logoutSuccess = createAction('[App Component] Logout Success');
export const userProfile = createAction('[App Component] User Profile');
export const userProfileSuccess = createAction('[App Component] User Profile Success', props<{ response: UserProfileResponse }>());
export const updateUserProfilePhoto = createAction('[App Component] Update User Profile Photo', props<{ command: UpdateProfilePhotoCommand }>());
export const updateUserProfilePhotoSuccess = createAction('[App Component] Update User Profile Photo Success', props<{ response: UpdateProfilePhotoResponse }>());
