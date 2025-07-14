import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { RoleDto } from "../roles/roleDto";
import { ClaimDto } from "src/app/generated-dto/claim-dto";

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

export interface UsersState extends EntityState<UserDto> {
}

export const initialUserState: UsersState = userAdapter.getInitialState();
