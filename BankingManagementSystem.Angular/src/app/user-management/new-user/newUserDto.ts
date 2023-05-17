import { ClaimDto } from "../claims/claimDto";
import { RoleDto } from "../roles/roleDto";
import { UserDto } from "../user-list/userDto";

export class NewUserDto{
  public userName:string = "admin@admin.com";
  public email:string = "admin@admin.com"
  public password:string = "1234";
  public confirmPassword: string = "1234";
  public roles: RoleDto[] | [] = [];
  public claims: ClaimDto[] | [] = [];
}
