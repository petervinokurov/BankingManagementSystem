import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { ClaimDto } from "../claims/claimDto";
import { RoleDto } from "../roles/roleDto";

export class UserDto{
  public id!:string;
  public userName!: string;
  public email!:string;
  public roles: RoleDto[] | [] = [];
  public claims: ClaimDto[] | [] = [];
}

export const userAdapter: EntityAdapter<UserDto> = createEntityAdapter<UserDto>({
  selectId: (user: UserDto) => user.id,
});

export interface UserState extends EntityState<UserDto> {}
