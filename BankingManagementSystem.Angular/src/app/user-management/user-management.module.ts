import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { UserManagementService } from './user-management.service';
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
    UserManagementRoutingModule,
    DxFormModule,
    DxButtonModule,
    DxDataGridModule
  ],
  providers: [
    UserManagementService
  ]
})
export class UserManagementModule { }
