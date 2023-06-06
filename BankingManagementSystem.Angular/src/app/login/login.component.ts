import { Component, OnInit } from '@angular/core';
import { LoginDto } from './loginDto';
import { Router } from '@angular/router';
import { UserManagementRoutes } from '../user-management/user-management-routes';
import { Store } from '@ngrx/store';
import { login, loginSuccess, userProfile } from '../app-state/app.actions';
import { selectUserLogin } from '../app-state/app.selectors';
import { Actions, ofType } from '@ngrx/effects';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public model:LoginDto = new LoginDto();
  isUserLogin$ = this.store.select(selectUserLogin);

  constructor(private readonly router:Router,
    private actions$: Actions,
    private readonly store:Store) { }

  ngOnInit(): void {
  }

  public async onLogin(){
    const loginDto = this.model;
    this.store.dispatch(login({loginDto}));
    this.actions$.pipe(ofType(loginSuccess)).subscribe(() => {
      this.store.dispatch(userProfile());
      this.router.navigate([UserManagementRoutes.Root,UserManagementRoutes.UserList]);
    });
  }
}
