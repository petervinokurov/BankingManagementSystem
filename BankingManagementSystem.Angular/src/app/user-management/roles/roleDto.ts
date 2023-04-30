import { ClaimDto } from "../claims/claimDto";

export class RoleDto{
  public id:string | undefined;
  public name:string | undefined;
  public concurrencyStamp:string | undefined;
  public roleClaims: ClaimDto[] = [];
}
