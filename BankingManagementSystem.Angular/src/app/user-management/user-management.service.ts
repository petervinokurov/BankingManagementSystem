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
	constructor(public httpService: HttpApiService) {
	}

	public createNewUser(
		request: NewUserDto,
		cancellationSubject: Observable<void>
	): Observable<BmsResponse> {
		return this.httpService.post<BmsResponse>(
			`${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewUser}`,
			request,
			cancellationSubject
		);
	}

  public getUserList(
    cancellationSubject:Observable<void>
    ): Observable<UserDto[]> {
    return this.httpService.get<UserDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UserList}`,
      cancellationSubject
    );
  }

  public getRolesList(
    cancellationSubject:Observable<void>
  ): Observable<RoleDto[]>{
    return this.httpService.get<RoleDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.RoleList}`,
      null,
      cancellationSubject
    );
  }

  public getClaimsList(
    cancellationSubject:Observable<void>
  ): Observable<ClaimDto[]>{
    return this.httpService.get<ClaimDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.ClaimList}`,
      null,
      cancellationSubject
    );
  }

  public createNewRoles(
    request:RoleDto[],
    cancellationSubject:Observable<void>
  ): Observable<RoleDto[]> {
    return this.httpService.post<RoleDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.CreateNewRoles}`,
      request,
      cancellationSubject
    );
  }

  public updateRoles(
    request:RoleDto[],
    cancellationSubject:Observable<void>
  ): Observable<RoleDto[]> {
    return this.httpService.put<RoleDto[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.UpdateRoles}`,
      request,
      cancellationSubject
    );
  }

  public deleteRoles(
    request:string[],
    cancellationSubject:Observable<void>
  ): Observable<string[]>{
    return this.httpService.delete<string[]>(
      `${UserManagementApiRoutes.Root}/${UserManagementApiRoutes.DeleteRoles}`,
      request,
      cancellationSubject
    );
  }

}
