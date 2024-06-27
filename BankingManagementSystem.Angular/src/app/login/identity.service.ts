import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpApiService } from "../common-services/http-api.service";
import { LoginDto } from "./loginDto";
import { IdentityApiRoutes } from "./identity-api-routes";
import { UserProfileResponse } from "../app-responses/user-profile-response";
import { UpdateProfilePhotoCommand } from "../app-requests/updateProfilePhotoRequest";
import { UpdateProfilePhotoResponse } from "../app-responses/user-photo-response";

@Injectable()
export class IdentityService {
	constructor(public httpService: HttpApiService) {
	}
  protected cancellationSubject: Observable<void> = new Observable();

	public login(
		request: LoginDto
	): Observable<LoginDto> {
		return this.httpService.post<LoginDto>(
			`${IdentityApiRoutes.Root}/${IdentityApiRoutes.Login}`,
			request,
			this.cancellationSubject
		);
	}

  public logout():Observable<void> {
    return this.httpService.get(`${IdentityApiRoutes.Root}/${IdentityApiRoutes.Logout}`, this.cancellationSubject);
  }

  public refreshToken():Observable<void> {
    return this.httpService.get(`${IdentityApiRoutes.Root}/${IdentityApiRoutes.RefreshToken}`, this.cancellationSubject);
  }

  public userProfile():Observable<UserProfileResponse>{
    return this.httpService.get(`${IdentityApiRoutes.Root}/${IdentityApiRoutes.UserProfile}`,this.cancellationSubject);
  }

  public updateUserProfilePhoto(request:UpdateProfilePhotoCommand): Observable<UpdateProfilePhotoResponse>{
    return this.httpService.post<UpdateProfilePhotoResponse>(`${IdentityApiRoutes.Root}/${IdentityApiRoutes.UpdateProfilePhoto}`, this.cancellationSubject);
  }
}
