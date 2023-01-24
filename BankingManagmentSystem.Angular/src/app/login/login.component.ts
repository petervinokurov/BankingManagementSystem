import { Component, OnInit } from '@angular/core';
import { LoginDto } from './loginDto';
import { IdentityService } from './identity.service';
import { lastValueFrom, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserManagmentRoutes } from '../user-managment/user-managment-routes';
import { AppEvents } from '../app-events';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
	protected cancellationObservable: Observable<void> = new Observable();
  public model:LoginDto = new LoginDto();

  constructor(private readonly service:IdentityService,
    private readonly events: AppEvents,
    private readonly router:Router) { }

  ngOnInit(): void {
  }

  public async onLogin(){
     var result = await lastValueFrom(this.service.login(this.model, this.cancellationObservable));
     if (result){
      this.router.navigate([UserManagmentRoutes.Root,UserManagmentRoutes.UserList]);
      this.events.LoginEmitter.emit();
     }
  }
}
