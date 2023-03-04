import { Component, OnInit } from '@angular/core';
import { NewUserDto } from './newUserDto';
import { UserManagmentService } from '../user-managment.service';
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
    useSubmitBehavior: true,
    //onclick: this.createNewUser()
  };
  passwordComparison = () => this.newUser.password;
  constructor(private readonly service:UserManagmentService,
    private readonly router:Router) { }

  ngOnInit(): void {
  }

  public async createNewUser(){
    var result = lastValueFrom(this.service.createNewUser(this.newUser, this.cancellationObservable));
    var b = await result;
    if (b){
      this.router.navigate([AppRoutes.Root]);
    }

  }

}
