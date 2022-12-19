import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../http-api.service";
import { NewUserDto } from "./new-user/newUserDto";
import { UserManagmentApiRoutes } from "./user-managment-routes";

@Injectable()
export class UserManagmentService {
	constructor(public httpService: HttpApiService) {
	}

	public createNewUser(
		request: NewUserDto,
		cancellationSubject: Observable<void>
	): Observable<NewUserDto> {
		return this.httpService.post<NewUserDto>(
			`${UserManagmentApiRoutes.Root}/${UserManagmentApiRoutes.CreateNewUser}`,
			request,
			cancellationSubject
		);
	}
}
