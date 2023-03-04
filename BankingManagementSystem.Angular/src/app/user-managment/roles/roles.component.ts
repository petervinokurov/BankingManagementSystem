import { Component, OnInit } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { UserManagmentService } from '../user-managment.service';
import { RoleDto } from './roleDto';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {

  protected cancellationObservable: Observable<void> = new Observable();
  public roles:RoleDto[] = [];

  constructor(private readonly service:UserManagmentService) { }

  async ngOnInit() {
    this.roles =  await lastValueFrom(this.service.getRolesList(this.cancellationObservable));
  }

  async saveRole(e:any, object:any){
    console.log(e);
    console.log(object);
  }
}
