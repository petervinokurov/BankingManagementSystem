import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../common-services/http-api.service";
import { LoginDto } from "./loginDto";
import { LoginApiRoutes } from "./loginRoutes";

@Injectable()
export class LoginService {
	constructor(public httpService: HttpApiService) {
	}

	public login(
		request: LoginDto,
		cancellationSubject: Observable<void>
	): Observable<LoginDto> {
		return this.httpService.post<LoginDto>(
			`${LoginApiRoutes.Root}/${LoginApiRoutes.Login}`,
			request,
			cancellationSubject
		);
	}
}
