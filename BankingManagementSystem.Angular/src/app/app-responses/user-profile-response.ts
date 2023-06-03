import { BmsResponse } from "../common-services/models/BmsResponse";
import { UserDto } from "../user-management/user-list/userDto";

export class UserProfileResponse extends BmsResponse {
  public user:UserDto | undefined;
}
