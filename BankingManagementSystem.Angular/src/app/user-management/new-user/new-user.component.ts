import { Component, OnInit } from '@angular/core';
import { NewUserDto } from './newUserDto';
import { UserManagementService } from '../user-management.service';
import { lastValueFrom, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AppRoutes } from 'src/app/app-routes';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.scss']
})
export class NewUserComponent implements OnInit {

  public newUser: NewUserDto = new NewUserDto();
  protected cancellationObservable: Observable<void> = new Observable();

  registerButtonOptions: any = {
    text: 'Register',
    type: 'primary',
    useSubmitBehavior: true
  };
  passwordComparison = () => this.newUser.password;
  constructor(private readonly service:UserManagementService,
    private readonly router:Router) { }

  ngOnInit(): void {
  }

  public async createNewUser(){
    var result = lastValueFrom(this.service.createNewUser(this.newUser));
    var b = await result;
    if (b){
      this.router.navigate([AppRoutes.Root]);
    }
  }
}
