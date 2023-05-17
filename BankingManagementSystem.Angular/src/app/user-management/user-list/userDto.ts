import { ClaimDto } from "../claims/claimDto";
import { RoleDto } from "../roles/roleDto";

export class UserDto{
  public id:string | undefined;
  public userName!: string;
  public email!:string;
  public roles: RoleDto[] | [] = [];
  public claims: ClaimDto[] | [] = [];
}
