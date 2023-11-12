import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../common-services/http-api.service";
import { BmsResponse } from "../common-services/models/BmsResponse";
import { NewUserDto } from "./new-user/newUserDto";
import { UserManagementApiRoutes } from "./user-management-api-routes";
import { UserDto } from "./user-list/userDto";
import { RoleDto } from "./roles/roleDto";
import { ClaimDto } from "./claims/claimDto";
import { CreateRolesCommand } from "./domain/createRolesRequest";
import { CreateRolesResponse } from "./domain/createRolesResponse";
import { DeleteRolesCommand } from "./domain/deleteRolesRequest";
import { DeleteRolesResponse } from "./domain/deleteRolesResponse";
import { UpdateRolesCommand } from "./domain/updateRolesRequest";
import { UpdateRolesResponse } from "./domain/updateRolesResponse";
import { CreateUsersCommand } from "./domain/createUsersRequest";
import { CreateUsersResponse } from "./domain/createUsersResponse";
import { DeleteUsersCommand } from "./domain/deleteUsersRequest";
import { DeleteUsersResponse } from "./domain/deleteUsersResponse";
import { UpdateUsersResponse } from "./domain/updateUsersResponse";
import { UpdateUsersCommand } from "./domain/updateUsersRequest";

@Injectable()
export class UserManagementService {

  protected cancellationSubject: Observable<void> = new Observable();

	constructor(public httpService: HttpApiService) {
	}

	public createNewUser(
		request: NewUserDto
	): Observable<BmsResponse> {
		return this.httpService.post<BmsResponse>(
			`${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewUser}`,
			request,
			this.cancellationSubject
		);
	}

  public createNewUsers(
    request:CreateUsersCommand
  ): Observable<CreateUsersResponse> {
    return this.httpService.post<CreateUsersResponse>(
			`${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewUsers}`,
			request,
			this.cancellationSubject
		);
  }

  public updateUsers(
    request:UpdateUsersCommand
  ): Observable<UpdateUsersResponse> {
    return this.httpService.put<UpdateUsersResponse>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UpdateUsers}`,
      request,
      this.cancellationSubject
    );
  }

  public deleteUsers(request:DeleteUsersCommand
  ): Observable<DeleteUsersResponse>{
    return this.httpService.delete<DeleteUsersResponse>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.DeleteUsers}`,
      request,
      this.cancellationSubject
    );
  }

  public getUserList(
    ): Observable<UserDto[]> {
    return this.httpService.get<UserDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UserList}`,
      this.cancellationSubject
    );
  }

  public getRolesList(
  ): Observable<RoleDto[]>{
    return this.httpService.get(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.RoleList}`,
      this.cancellationSubject
    );
  }

  public getClaimsList(
  ): Observable<ClaimDto[]>{
    return this.httpService.get(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.ClaimList}`,
      this.cancellationSubject
    );
  }

  public createNewRoles(
    request:CreateRolesCommand
  ): Observable<CreateRolesResponse> {
    return this.httpService.post<CreateRolesResponse>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewRoles}`,
      request,
      this.cancellationSubject
    );
  }

  public updateRoles(
    request:UpdateRolesCommand
  ): Observable<UpdateRolesResponse> {
    return this.httpService.put<UpdateRolesResponse>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UpdateRoles}`,
      request,
      this.cancellationSubject
    );
  }

  public deleteRoles(
    request:DeleteRolesCommand
  ): Observable<DeleteRolesResponse>{
    return this.httpService.delete<DeleteRolesResponse>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.DeleteRoles}`,
      request,
      this.cancellationSubject
    );
  }

}
