import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { ClaimDto } from "../claims/claimDto";

export class RoleDto{
  public id!:string;
  public name!:string;
  public concurrencyStamp!:string;
  public roleClaimsIds: string[] | [] = [];
  public roleClaims: ClaimDto[] | ClaimDto[] = [];
}

export const roleAdapter: EntityAdapter<RoleDto> = createEntityAdapter<RoleDto>({
  selectId: (role: RoleDto) => role.id,
});

export interface RolesState extends EntityState<RoleDto> {
}

export const initialRoleState: RolesState = roleAdapter.getInitialState();
