import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { IdentityService } from '../login/identity.service';
import { login, loginSuccess, logout, logoutSuccess, refreshTokenSuccess, updateUserProfilePhoto, updateUserProfilePhotoSuccess, userProfile, userProfileSuccess, userTokenInvalid, userTokenValid } from './app.actions';
import { map, mergeMap, tap, } from 'rxjs';
import { UserProfileResponse } from '../app-responses/user-profile-response';
import { UpdateProfilePhotoResponse } from '../app-responses/user-photo-response';
import { SignalRService } from '../common-services/signalr-hub-service';

@Injectable()
export class AppEffects {

  constructor(private actions$: Actions,
    private service:IdentityService,
    private signalR: SignalRService ) {}

  login$ = createEffect(
    () => this.actions$.pipe(ofType(login),
    mergeMap( (action) =>
       this.service.login(action.loginDto).pipe(map(() => loginSuccess()))
  )));

  connectSignalR$ = createEffect(
  () =>
    this.actions$.pipe(
      ofType(userTokenValid),
      tap(() => {
        this.signalR.init();
      })
    ),
    { dispatch: false }
  );

  logout$ = createEffect(
    () => this.actions$.pipe(ofType(logout),
      mergeMap(() => this.service.logout().pipe(map(() => logoutSuccess()))
  )));

  userProfile$ = createEffect(
    () => this.actions$.pipe(ofType(userProfile),
    mergeMap(() => this.service.userProfile().pipe(map((response:UserProfileResponse) => userProfileSuccess({response})))))
  );

  userTokenInvalid$ = createEffect(
    () => this.actions$.pipe(ofType(userTokenInvalid),
    mergeMap(() => this.service.refreshToken().pipe(map(() => refreshTokenSuccess()))))
  );

  updateUserProfilePhoto$ = createEffect(
    () => this.actions$.pipe(ofType(updateUserProfilePhoto),
      mergeMap((request) =>
         this.service.updateUserProfilePhoto(request.command).pipe(map((response: UpdateProfilePhotoResponse) => updateUserProfilePhotoSuccess({response}))))));
}
