import { Component } from '@angular/core';
import { AuthenticationService } from './authentication/authentication.service';
import { LoginService } from './authentication/login/service/login.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent {
    title = 'app';
    constructor(private authenticationService: AuthenticationService, private loginService: LoginService) {
    }

}