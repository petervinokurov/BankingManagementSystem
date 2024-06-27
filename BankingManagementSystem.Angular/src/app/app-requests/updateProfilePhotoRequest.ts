import { BmsResponse } from "../common-services/models/BmsResponse";

export class UpdateProfilePhotoCommand {
  public userId!: string;
  public photo: string = '';
}
