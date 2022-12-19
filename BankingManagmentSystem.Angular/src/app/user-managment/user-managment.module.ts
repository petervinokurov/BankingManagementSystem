import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagmentRoutingModule } from './user-managment-routing.module';
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
  ]
})
export class UserManagmentModule { }
