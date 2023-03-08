import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom, Observable } from 'rxjs';
import { AppEvents } from './app-events';
import { IdentityService } from './login/identity.service';
import { AppRoutes } from './app-routes';
import { CookieService } from 'ngx-cookie-service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  protected cancellationObservable: Observable<void> = new Observable();

  public isUserLogin:boolean = false;
  constructor(private readonly service:IdentityService,
    private readonly events:AppEvents,
    private readonly router:Router,
    private readonly cookie:CookieService,
    private jwtHelper: JwtHelperService
  ){}

  public ngOnInit(){
    this.events.LoginEmitter.subscribe(x => this.isUserLogin = true);
    this.events.LogoutEmitter.subscribe(x => {
      this.cookie.delete('Token');
      this.isUserLogin = false
    });
    if (this.cookie.get('Token') && !this.jwtHelper.isTokenExpired(this.cookie.get('Token'))){
      this.isUserLogin = true;
    }
  }

  public async onLogOut(){
    await lastValueFrom(this.service.logout(this.cancellationObservable));
    this.isUserLogin = false;
    this.router.navigate([AppRoutes.Root]);
  }
}
