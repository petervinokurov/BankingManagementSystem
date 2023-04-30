import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewUserComponent } from './new-user/new-user.component';
import { RolesComponent } from './roles/roles.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserManagementRoutes } from './user-management-routes';
import { ClaimsComponent } from './claims/claims.component';

const routes: Routes = [
  {path: "new-user", component: NewUserComponent},
  {path: "user-list", component: UserListComponent},
  {path: "roles", component: RolesComponent},
  { path: UserManagementRoutes.Claims, component: ClaimsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserManagementRoutingModule { }
