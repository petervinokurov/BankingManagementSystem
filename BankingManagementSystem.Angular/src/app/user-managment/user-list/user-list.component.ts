import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagmentService } from '../user-managment.service';
import { UserDto } from './userDto';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  protected cancellationObservable: Observable<void> = new Observable();

  public users:UserDto[] = [];

  constructor(private readonly service: UserManagmentService) {
  }

  async ngOnInit() {
    this.users = await lastValueFrom(this.service.getUserList(this.cancellationObservable));
    console.log(this.users);
    //this.dataSource.items = () => this.users;
    //this.dataSource.load();
  }
}
