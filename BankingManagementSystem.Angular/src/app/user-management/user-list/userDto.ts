import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { UserDto } from "src/app/generated-dto/user-dto";

export const userAdapter: EntityAdapter<UserDto> = createEntityAdapter<UserDto>({
  selectId: (user: UserDto) => user.id,
});

export interface UsersState extends EntityState<UserDto> {
}

export const initialUserState: UsersState = userAdapter.getInitialState();
