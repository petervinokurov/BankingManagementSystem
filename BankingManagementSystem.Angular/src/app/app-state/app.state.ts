import { UserProfileState } from "../app-components/user-profile/userProfileDto";

export interface AppState{
  isLogin: boolean,
  currentUserId: string,
  userProfile: UserProfileState
}


