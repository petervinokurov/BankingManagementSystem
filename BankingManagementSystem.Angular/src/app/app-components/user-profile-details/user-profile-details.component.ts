import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppRoutes } from 'src/app/app-routes';
import { logout, logoutSuccess } from 'src/app/app-state/app.actions';
import { AppState } from 'src/app/app-state/app.state';

@Component({
  selector: 'app-user-profile-details',
  templateUrl: './user-profile-details.component.html',
  styleUrls: ['./user-profile-details.component.scss']
})
export class UserProfileDetailsComponent {

  constructor(private readonly actions$:Actions,
    private readonly router:Router,
    private readonly store:Store<AppState>){

  }

  public async onLogOut(){
    this.store.dispatch(logout());
    this.actions$.pipe(ofType(logoutSuccess)).subscribe(() => {
      this.router.navigate([AppRoutes.Root]);
    });
  }
}
