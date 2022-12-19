import { Component, OnInit, ViewChild } from '@angular/core';
import { NewUserDto } from './newUserDto';
import { UserManagmentService } from '../user-managment.service';
import { lastValueFrom, Observable } from 'rxjs';

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
    onclick: this.createNewUser()
  };
  passwordComparison = () => this.newUser.password;
  constructor(private readonly service:UserManagmentService) { }

  ngOnInit(): void {
  }

  private createNewUser(){
    lastValueFrom(this.service.createNewUser(this.newUser, this.cancellationObservable));
  }

}
