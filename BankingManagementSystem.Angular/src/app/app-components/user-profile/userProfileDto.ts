import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";

export class UserProfileDto{
  public id!:string;
  public userName!: string;
  public email!:string;
  public profilePicture: number[] | undefined;
}

export const userProfileAdapter: EntityAdapter<UserProfileDto> = createEntityAdapter<UserProfileDto>({
  selectId: (userProfile: UserProfileDto) => userProfile.id,
});

export interface UserProfileState extends EntityState<UserProfileDto> {
}

export const initialUserProfileState: UserProfileState = userProfileAdapter.getInitialState();
