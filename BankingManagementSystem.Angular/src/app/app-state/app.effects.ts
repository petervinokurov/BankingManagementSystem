import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { IdentityService } from '../login/identity.service';
import { login, loginSuccess, logout, logoutSuccess, userProfile, userProfileSuccess } from './app.actions';
import { map, mergeMap, } from 'rxjs';
import { UserProfileResponse } from '../app-responses/user-profile-response';

@Injectable()
export class AppEffects {

  constructor(private actions$: Actions,
    private service:IdentityService ) {}

  login$ = createEffect(
    () => this.actions$.pipe(ofType(login),
    mergeMap( (action) =>
       this.service.login(action.loginDto).pipe(map(() => loginSuccess()))
  )));

  logout$ = createEffect(
    () => this.actions$.pipe(ofType(logout),
      mergeMap(() => this.service.logout().pipe(map(() => logoutSuccess()))
  )));

  userProfile$ = createEffect(
    () => this.actions$.pipe(ofType(userProfile),
    mergeMap(() => this.service.userProfile().pipe(map((response:UserProfileResponse) => userProfileSuccess({response})))))
  );
}
