import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom, Observable } from 'rxjs';
import { AppEvents } from './app-events';
import { IdentityService } from './login/identity.service';
import { AppRoutes } from './app-routes';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  protected cancellationObservable: Observable<void> = new Observable();

  public isLogOutHidden:boolean = true;
  constructor(private readonly service:IdentityService,
    private readonly events:AppEvents,
    private readonly router:Router,
    private readonly cookie:CookieService
  ){}

  public ngOnInit(){
    this.events.LoginEmitter.subscribe(x => this.isLogOutHidden = false);
    this.events.LogoutEmitter.subscribe(x => this.isLogOutHidden = true);
    if (this.cookie.get('Token')){
      this.isLogOutHidden = false;
    }
  }

  public async onLogOut(){
    await lastValueFrom(this.service.logout());
    this.isLogOutHidden = true;
    this.router.navigate([AppRoutes.Root]);
  }
}
