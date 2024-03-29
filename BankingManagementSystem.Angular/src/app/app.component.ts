import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Store } from '@ngrx/store';
import { refreshTokenSuccess, userProfile, userTokenInvalid, userTokenValid } from './app-state/app.actions';
import { selectUserLogin } from './app-state/app.selectors';
import { Actions, ofType } from '@ngrx/effects';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  protected cancellationObservable: Observable<void> = new Observable();
  isUserLogin$ = this.store.select(selectUserLogin);
  title = "Banking Management System";

  constructor(
    private readonly cookie:CookieService,
    private readonly jwtHelper: JwtHelperService,
    private actions$: Actions,
    private store:Store,
    private router:Router
  ){}

  public onNavigateRoles(){
    this.router.navigate(["user-management/roles"]);
  }

  public onNavigateClaims(){
    this.router.navigate(["user-management/claims"]);
  }

  public onNavigateUsers(){
    this.router.navigate(["user-management/user-list"]);
  }

  public ngOnInit(){
    if (this.cookie.get('Token') && !this.jwtHelper.isTokenExpired(this.cookie.get('Token')) ){
      this.store.dispatch(userTokenValid());
      this.store.dispatch(userProfile());
    }else{
      this.store.dispatch(userTokenInvalid());

      this.actions$.pipe(ofType(refreshTokenSuccess)).subscribe(() => {
        this.store.dispatch(userProfile());
      });
    }
  }
}
