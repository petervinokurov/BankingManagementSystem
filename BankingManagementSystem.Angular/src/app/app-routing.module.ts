import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserProfileDetailsComponent } from './app-components/user-profile-details/user-profile-details.component';

const routes: Routes = [
  {path: "", component: LoginComponent},
  {path: "user-details", component: UserProfileDetailsComponent},
  {path: "user-management",
    loadChildren: () => import("./user-management/user-management.module").then((m) => m.UserManagementModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
