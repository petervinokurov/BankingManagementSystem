import { Component, OnInit } from '@angular/core';
import { LoginDto } from './loginDto';
import { LoginService } from './login.service';
import { lastValueFrom, Observable , Subscriber} from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


	protected cancellationObservable: Observable<void> = new Observable();

  public model:LoginDto = new LoginDto();

  constructor(private readonly service:LoginService,
    private readonly http: HttpClient) { }

  ngOnInit(): void {
  }

  public onLogin(){
     lastValueFrom(this.service.login(this.model, this.cancellationObservable));
  }
}
