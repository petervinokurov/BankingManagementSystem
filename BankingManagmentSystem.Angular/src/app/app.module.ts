import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login/login.service';
import {APP_BASE_HREF} from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpApiService } from './http-api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { UserManagmentModule } from './user-managment/user-managment.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    UserManagmentModule,
    NgbModule
  ],
  providers: [{provide: APP_BASE_HREF, useValue: '/ClientApp'}, LoginService, HttpApiService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
