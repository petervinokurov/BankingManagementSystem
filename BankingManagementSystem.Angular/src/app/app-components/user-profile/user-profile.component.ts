import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/app/app-state/app.state';
import { selectUserProfile } from 'src/app/app-state/app.selectors';
import { Router } from '@angular/router';
import { AppRoutes } from 'src/app/app-routes';
import { UserProfileDto } from './userProfileDto';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})

export class UserProfileComponent {
  protected cancellationObservable: Observable<void> = new Observable();

  public userProfile$: Observable<UserProfileDto | undefined> = this.store.select(selectUserProfile);

  constructor(
    private readonly router:Router,
    private readonly store:Store<AppState>){}

  public ngOnInit(){
  }

  userDetails() {
    this.router.navigate([AppRoutes.UserDetails]);
  }

}
