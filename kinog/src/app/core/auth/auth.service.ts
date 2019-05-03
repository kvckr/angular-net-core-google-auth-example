import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITokenModel } from './token.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private readonly http: HttpClient) { }

  public authenticate(googleUser) {
    this.onSignIn(googleUser);
  }

  public getAuthInfo(): string {
    return JSON.parse(localStorage.getItem('authToken'));
  }

  public isAuthorized(): boolean {
    return !!localStorage.getItem('authToken');
  }

  public getTestData(): Observable<string> {
    return this.http.get<string>(environment.apiUrl+'authentication');
  }

  private onSignIn(googleUser) {
    this.http.post<ITokenModel>(environment.apiUrl+'authentication', '\''+googleUser.Zi.id_token+'\'')
    .subscribe(result => this.onSuccess(result));
  }

  private onSuccess(token: ITokenModel) {
    localStorage.setItem('authToken', JSON.stringify(token.auth_token));
  }
}
