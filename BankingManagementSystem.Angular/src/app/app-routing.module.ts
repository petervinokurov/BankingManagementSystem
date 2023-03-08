import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserManagementModule } from './user-management/user-management.module';

const routes: Routes = [
  {path: "", component: LoginComponent},
  {path: "user-management",
    loadChildren: () => import("./user-management/user-management.module").then((m) => m.UserManagementModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
