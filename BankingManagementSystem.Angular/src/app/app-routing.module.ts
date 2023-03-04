import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserManagmentModule } from './user-managment/user-managment.module';

const routes: Routes = [
  {path: "", component: LoginComponent},
  {path: "user-managment",
    loadChildren: () => import("./user-managment/user-managment.module").then((m) => m.UserManagmentModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
