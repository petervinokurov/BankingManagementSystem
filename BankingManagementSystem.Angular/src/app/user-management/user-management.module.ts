import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { UserManagementService } from './user-management.service';
import { NewUserComponent } from './new-user/new-user.component';
import { DxFormModule, DxButtonModule, DxDataGridModule, DxTagBoxModule, DxTemplateModule} from 'devextreme-angular';
import { UserListComponent } from './user-list/user-list.component';
import { RolesComponent } from './roles/roles.component';
import { ClaimsComponent } from './claims/claims.component';


@NgModule({
  declarations: [
    NewUserComponent,
    UserListComponent,
    RolesComponent,
    ClaimsComponent
  ],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    DxFormModule,
    DxButtonModule,
    DxDataGridModule,
    DxTagBoxModule,
    DxTemplateModule
  ],
  providers: [
    UserManagementService
  ]
})
export class UserManagementModule { }
