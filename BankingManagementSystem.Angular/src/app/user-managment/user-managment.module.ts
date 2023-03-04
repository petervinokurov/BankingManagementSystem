import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagmentRoutingModule } from './user-managment-routing.module';
import { UserManagmentService } from './user-managment.service';
import { NewUserComponent } from './new-user/new-user.component';
import { DxFormModule, DxButtonModule, DxDataGridModule} from 'devextreme-angular';
import { UserListComponent } from './user-list/user-list.component';
import { RolesComponent } from './roles/roles.component';


@NgModule({
  declarations: [
    NewUserComponent,
    UserListComponent,
    RolesComponent
  ],
  imports: [
    CommonModule,
    UserManagmentRoutingModule,
    DxFormModule,
    DxButtonModule,
    DxDataGridModule
  ],
  providers: [
    UserManagmentService
  ]
})
export class UserManagmentModule { }
