import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/app/app-state/app.state';
import { selectUserEmail, selectUserName } from 'src/app/app-state/app.selectors';
import { Router } from '@angular/router';
import { AppRoutes } from 'src/app/app-routes';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})

export class UserProfileComponent {
  protected cancellationObservable: Observable<void> = new Observable();

  userEmail$ = this.store.select(selectUserEmail);
  userName$ = this.store.select(selectUserName);

  constructor(
    private readonly router:Router,
    private readonly store:Store<AppState>){}

  public ngOnInit(){
  }

  userDetails() {
    this.router.navigate([AppRoutes.UserDetails]);
  }

}
