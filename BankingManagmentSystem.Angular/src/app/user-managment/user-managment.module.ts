import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagmentRoutingModule } from './user-managment-routing.module';
import { UserManagmentService } from './user-managment.service';
import { NewUserComponent } from './new-user/new-user.component';
import { DxFormModule, DxButtonModule} from 'devextreme-angular';

@NgModule({
  declarations: [
    NewUserComponent
  ],
  imports: [
    CommonModule,
    UserManagmentRoutingModule,
    DxFormModule,
    DxButtonModule
  ],
  providers: [
    UserManagmentService
  ]
})
export class UserManagmentModule { }
