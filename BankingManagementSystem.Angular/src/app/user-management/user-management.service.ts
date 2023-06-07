import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../common-services/http-api.service";
import { BmsResponse } from "../common-services/models/BmsResponse";
import { NewUserDto } from "./new-user/newUserDto";
import { UserManagementApiRoutes } from "./user-management-api-routes";
import { UserDto } from "./user-list/userDto";
import { RoleDto } from "./roles/roleDto";
import { ClaimDto } from "./claims/claimDto";

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
    request:NewUserDto[]
  ): Observable<BmsResponse> {
    return this.httpService.post<BmsResponse>(
			`${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewUsers}`,
			request,
			this.cancellationSubject
		);
  }

  public updateUsers(
    request:UserDto[]
  ): Observable<UserDto[]> {
    return this.httpService.put<UserDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UpdateUsers}`,
      request,
      this.cancellationSubject
    );
  }

  public deleteUsers(request:string[]
  ): Observable<string[]>{
    return this.httpService.delete<string[]>(
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
    request:RoleDto[]
  ): Observable<RoleDto[]> {
    return this.httpService.post<RoleDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewRoles}`,
      request,
      this.cancellationSubject
    );
  }

  public updateRoles(
    request:RoleDto[]
  ): Observable<RoleDto[]> {
    return this.httpService.put<RoleDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UpdateRoles}`,
      request,
      this.cancellationSubject
    );
  }

  public deleteRoles(
    request:string[]
  ): Observable<string[]>{
    return this.httpService.delete<string[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.DeleteRoles}`,
      request,
      this.cancellationSubject
    );
  }

}
