import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { ClaimDto } from "src/app/generated-dto/claim-dto";
import { RoleDto } from "src/app/generated-dto/role-dto";

export const roleAdapter: EntityAdapter<RoleDto> = createEntityAdapter<RoleDto>({
  selectId: (role: RoleDto) => role.id,
});

export interface RolesState extends EntityState<RoleDto> {
}

export const initialRoleState: RolesState = roleAdapter.getInitialState();
