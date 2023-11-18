import { UserProfileDto } from "../app-components/user-profile/userProfileDto";
import { BmsResponse } from "../common-services/models/BmsResponse";

export class UserProfileResponse extends BmsResponse {
  public user!: UserProfileDto;
}
