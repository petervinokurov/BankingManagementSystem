import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagementService } from '../user-management.service';
import { UserDto } from './userDto';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  protected cancellationObservable: Observable<void> = new Observable();

  public users:UserDto[] = [];

  constructor(private readonly service: UserManagementService) {
  }

  async ngOnInit() {
    this.users = await lastValueFrom(this.service.getUserList(this.cancellationObservable));
  }
}
