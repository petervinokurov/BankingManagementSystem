import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../common-services/http-api.service";
import { LoginDto } from "./loginDto";
import { IdentityApiRoutes } from "./identity-api-routes";

@Injectable()
export class IdentityService {
	constructor(public httpService: HttpApiService) {
	}

	public login(
		request: LoginDto,
		cancellationSubject: Observable<void>
	): Observable<LoginDto> {
		return this.httpService.post<LoginDto>(
			`${IdentityApiRoutes.Root}/${IdentityApiRoutes.Login}`,
			request,
			cancellationSubject
		);
	}

  public logout(
    cancellationSubject: Observable<void>
  ):Observable<void> {
    return this.httpService.get<void>(`${IdentityApiRoutes.Root}/${IdentityApiRoutes.Logout}`, null, cancellationSubject);
  }
}
