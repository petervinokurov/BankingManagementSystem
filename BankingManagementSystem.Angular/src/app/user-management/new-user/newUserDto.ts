import { ClaimDto } from "src/app/generated-dto/claim-dto";
import { RoleDto } from "src/app/generated-dto/role-dto";

export class NewUserDto{
  public userName:string = "admin@admin.com";
  public email:string = "admin@admin.com"
  public password:string = "1234";
  public confirmPassword: string = "1234";
  public roles: RoleDto[] | [] = [];
  public claims: ClaimDto[] | [] = [];
}
