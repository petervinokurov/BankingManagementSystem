import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserProfileDetailsComponent } from './app-components/user-profile-details/user-profile-details.component';
import { ProfilePictureCropperComponent } from './app-components/user-profile-details/profile-picture-cropper/profile-picture-cropper.component';
import { AppRoutes, UserProfileRoutes } from './app-routes';

const routes: Routes = [
  {path: "", component: LoginComponent},
  {path: "swagger", redirectTo: "swagger/index.html"},
  {path: AppRoutes.UserDetails, component: UserProfileDetailsComponent,
    children: [
      {path: UserProfileRoutes.ProfilePicture, component: ProfilePictureCropperComponent}
    ]
  },
  {path: "user-management",
    loadChildren: () => import("./user-management/user-management.module").then((m) => m.UserManagementModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
